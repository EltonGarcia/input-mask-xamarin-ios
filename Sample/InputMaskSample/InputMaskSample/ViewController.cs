using System;
using System.Diagnostics;
using Foundation;
using InputMask.Classes.View;
using UIKit;

namespace InputMaskSample
{
    public partial class ViewController : UIViewController, IMaskedTextFieldDelegateListener
    {
        MaskedTextFieldDelegate maskedDelegate;

        protected ViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            maskedDelegate = new MaskedTextFieldDelegate("8 ([000]) [000] [00] [00]");
            maskedDelegate.Listener = this;

            field.Delegate = maskedDelegate;
        }

        public void TextField(IUITextInput textField, bool complete, string value)
        {
            Debug.WriteLine(value);
        }

        [Export("textField:shouldChangeCharactersInRange:replacementString:")]
        public bool ShouldChangeCharacters(UITextField textField, Foundation.NSRange range, string replacementString)
        {
            Debug.WriteLine(textField.Text);
            return true;
        }
    }
}
