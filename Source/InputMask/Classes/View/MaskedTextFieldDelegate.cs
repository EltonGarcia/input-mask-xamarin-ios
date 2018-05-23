using System;
using Foundation;
using InputMask.Classes.Model;
using UIKit;

namespace InputMask.Classes.View
{
    public class MaskedTextFieldDelegate : UITextFieldDelegate, IUITextFieldDelegate
    {
        private string _maskFormat;
        private bool _autocomplete;
        private bool _autocompleteOnFocus;

        public Mask mask;

        private IMaskedTextFieldDelegateListener listener;

        public IMaskedTextFieldDelegateListener Listener
        {
            get { return listener; }
            set { listener = value; }
        }

        public string MaskFormat
        {
            get { return _maskFormat; }
            set
            {
                _maskFormat = value;
                mask = Mask.GetOrCreate(value);
            }
        }

        public bool AutoComplete
        {
            get
            {
                return _autocomplete;
            }
            set
            {
                _autocomplete = value;
            }
        }

        public bool AutoCompleteOnFocus
        {
            get
            {
                return _autocompleteOnFocus;
            }
            set
            {
                _autocompleteOnFocus = value;
            }
        }

        public MaskedTextFieldDelegate(string format)
        {
            _maskFormat = format;
            mask = Mask.GetOrCreate(format);
            _autocomplete = _autocompleteOnFocus = false;
        }

        public MaskedTextFieldDelegate() : this(string.Empty)
        {
        }

        public void Put(string text, UITextField field)
        {
            var result = mask.Apply(new CaretString(text, text.Length - 1), _autocomplete);
            field.Text = result.FormattedText.Content;
            var position = result.FormattedText.CaretPosition;
            SetCaretPosition(position, field);
            listener?.TextField(field, result.Complete, result.ExtractedValue);
        }

        public string Placeholder()
        {

            return mask.Placeholder();
        }

        public int AcceptableTextLength()
        {
            return mask.AcceptableTextLength();
        }

        public int TotalTextLength()
        {
            return mask.TotalTextLength();
        }

        public int AcceptableValueLength()
        {
            return mask.AcceptableValueLength();
        }

        public int TotalValueLength()
        {
            return mask.TotalValueLength();
        }

        public override bool ShouldChangeCharacters(UITextField textField, NSRange range, string replacementString)
        {
			string extractedValue;
			bool complete;

			if (IsDeletion(range, replacementString))
			{
				extractedValue = DeleteText(range, textField, out complete);
			}
			else
			{
				extractedValue = ModifyText(range, textField, replacementString, out complete);
			}

			listener.TextField(textField, complete, extractedValue);
			listener.ShouldChangeCharacters(textField, range, replacementString);
			return false;
        }

        public string DeleteText(NSRange range, UITextField field, out bool complete)
        {
            var text = ReplaceCharacters(field.Text, range, string.Empty);
            var result = mask.Apply(new CaretString(text, range.Location), false);
            field.Text = result.FormattedText.Content;
            SetCaretPosition(range.Location, field);

            complete = result.Complete;
            return result.ExtractedValue;
        }

        public string ModifyText(NSRange range, UITextField field, string content, out bool complete)
        {
            var updatedText = ReplaceCharacters(field.Text, range, content);
            var result = mask.Apply(new CaretString(updatedText, CaretPosition(field) + content.Length), AutoComplete);

            field.Text = result.FormattedText.Content;

            var position = result.FormattedText.CaretPosition;
            SetCaretPosition(position, field);

            complete = result.Complete;
            return result.ExtractedValue;
        }

		public void SelectionWillChange(IUITextInput uiTextInput)
		{
			var field = uiTextInput as UITextField;
            if (field != null)
            {
                field.ShouldBeginEditing(field);
            }
		}

		public void SelectionDidChange(IUITextInput uiTextInput)
		{
			var field = uiTextInput as UITextField;
            if (field != null)
            {
                listener.ShouldEndEditing(field);
            }
		}

		public void TextWillChange(IUITextInput textField)
		{
            var field = textField as UITextField;
            if (field != null)
            {
                if (AutoCompleteOnFocus && string.IsNullOrEmpty(textField.ToString()))
                {
                    ShouldChangeCharacters(field, new NSRange(0, 0), string.Empty);
                }
                listener.EditingStarted(field);
            }
		}

		public void TextDidChange(IUITextInput textField)
		{
			var field = textField as UITextField;
            if (field != null)
            {
                listener.EditingEnded(field);
            }
		}

        public bool TextFieldShouldClear(UITextField textField)
        {
            var shouldClear = listener.ShouldClear(textField);
            if (shouldClear)
            {
                var result = mask.Apply(new CaretString(string.Empty, 0), AutoComplete);
                listener.TextField(textField, result.Complete, result.ExtractedValue);
            }
            return shouldClear;
        }

        public bool TextFieldShouldReturn(UITextField textField)
        {
            return listener.ShouldReturn(textField);
        }

        public bool IsDeletion(NSRange range, string content)
        {
            return range.Length > 0 && content.Length == 0;
        }

        public string ReplaceCharacters(string text, NSRange range, string newText)
        {
            if (text != null)
            {
				var strg = new NSString(text);
				var result = new NSMutableString();
				result.Append(strg);
                var newContent = new NSString(newText);

                if (range.Length > 0)
                {
                    return result.Replace(range, newContent).ToString();
                }
                else
                {
                    result.Insert(newContent, range.Location);
                    return result;
                }
            }
            return string.Empty;
        }

        public nint CaretPosition(UITextField field)
        {
            if (!field.IsFirstResponder)
                return field.Text.Length;

            var range = field.SelectedTextRange;
            if (range != null)
            {
                var selectedTextLocation = range.Start;
                return field.GetOffsetFromPosition(field.BeginningOfDocument, selectedTextLocation);
            }
            return 0;
        }

        public void SetCaretPosition(nint position, UITextField field)
        {
            if (!field.IsFirstResponder)
                return;

            if (position > field.Text.Length)
                return;

            var from = field.GetPosition(field.BeginningOfDocument, position);
            var to = field.GetPosition(from, 0);
            field.SelectedTextRange = field.GetTextRange(from, to);
        }
    }
}
