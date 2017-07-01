using System;
using System.Collections.Generic;
using System.Diagnostics;
using InputMask.Classes.Helper;
using InputMask.Classes.Model;
using InputMask.Classes.Model.States;
using static InputMask.Classes.Model.States.ValueState;

namespace InputMask.Classes
{
    [DebuggerDisplay("{DebugDescription()}")]
    public class Mask
    {
        [DebuggerDisplay("{DebugDescription()}")]
        public class Result
        {
            public CaretString FormattedText;
            public string ExtractedValue;
            public int Affinity;
            public bool Complete;

            public string DebugDescription()
            {
                return $"FORMATTED TEXT: {FormattedText}) EXTRACTED VALUE: {ExtractedValue} AFFINITY: {Affinity} COMPLETE: {Complete}";
            }
        }

        private State initialState;
        private static Dictionary<string, Mask> cache = new Dictionary<string, Mask>();

        public Mask(string format)
        {
            initialState = new Compiler().Compile(format);
        }

        public static Mask GetOrCreate(string format)
        {
            Mask cachedMask;
            if (cache.TryGetValue(format, out cachedMask))
                return cachedMask;

            cachedMask = new Mask(format);
            cache.Add(format, cachedMask);
            return cachedMask;
        }

        public Result Apply(CaretString text, bool autocomplete = false)
        {
            var interator = new CaretStringIterator(text);

            var affinity= 0;
            var extractedValue = string.Empty;
            var modifiedString = string.Empty;
            var modifiedCaretPosition = text.CaretPosition;

            var state = initialState;
            var beforeCaret = interator.BeforeCaret();
            var character = interator.Next();

            while (character.HasValue)
            {
                var next = state.Accept(character.Value);
                if (next != null)
                {
                    state = next.State;
                    modifiedString += next.Insert != null ? new String(next.Insert.Value, 1) : string.Empty;
                    extractedValue += next.Value != null ? new String(next.Value.Value, 1) : string.Empty;

                    if (next.Pass)
                    {
                        beforeCaret = interator.BeforeCaret();
                        character = interator.Next();
                        affinity += 1;
                    }
                    else
                    {
                        if (beforeCaret && next.Insert != null)
                        {
                            modifiedCaretPosition += 1;
                        }
                        affinity -= 1;
                    }
                }
                else
                {
                    if (interator.BeforeCaret())
                    {
                        modifiedCaretPosition -= 1;
                    }
                    beforeCaret = interator.BeforeCaret();
                    character = interator.Next();
                    affinity -= 1;
                }
            }

            Next nextAC;
            while (autocomplete && beforeCaret && (nextAC = state.Autocomplete()) != null)
            {
                state = nextAC.State;
                modifiedString += nextAC.Insert.HasValue ? new string(nextAC.Insert.Value, 1) : string.Empty;
                extractedValue += nextAC.Value.HasValue ? new string(nextAC.Value.Value, 1) : string.Empty;
                if (nextAC.Insert.HasValue)
                {
                    modifiedCaretPosition += 1;
                }
            }

            return new Result {
                FormattedText = new CaretString(modifiedString, modifiedCaretPosition),
                ExtractedValue = extractedValue,
                Affinity = affinity,
                Complete = NoMandatoryCharactersLeftAfterState(state)
            };
        }

        public string Placeholder()
        {
            return AppendPlaceHolder(initialState, string.Empty);
        }

        public int AcceptableTextLength()
        {
            var state = initialState;
            var length = 0;

            State s;
            while ((s = state) != null && !(state is EOLState))
            {
                if (s is FixedState || s is FreeState || s is ValueState)
                    length++;
                state = s.Child;
            }
            return length;
        }

        public int TotalTextLength()
        {
            var state = initialState;
            var length = 0;
            while (!(state is EOLState))
            {
                if (state is FixedState || state is FreeState || state is ValueState || state is OptionalValueState)
					length++;
                state = state.Child;
            }
            return length;
        }

        public int AcceptableValueLength()
        {
			var state = initialState;
			var length = 0;
			while (!(state is EOLState))
			{
				if (state is FixedState || state is ValueState)
					length++;
				state = state.Child;
			}
			return length;
        }

		public int TotalValueLength()
		{
			var state = initialState;
			var length = 0;
			while (!(state is EOLState))
			{
                if (state is FixedState || state is ValueState || state is OptionalValueState)
					length++;
				state = state.Child;
			}
			return length;
		}

        public string AppendPlaceHolder(State state, string placeholder)
        {
            if (state == null)
                return placeholder;

            if (state is EOLState)
                return placeholder;

            if (state is FixedState)
			{
				var fixedState = state as FixedState;
				return AppendPlaceHolder(fixedState.Child, placeholder + fixedState.OwnCharacter);
			}

            if (state is FreeState)
            {
                var freeState = state as FreeState;
                return AppendPlaceHolder(freeState.Child, placeholder + freeState.OwnCharacter);
            }

            if (state is OptionalValueState)
			{
				var optState = state as OptionalValueState;
				switch (optState.Type)
				{
					case StateType.AlphaNumeric:
						return AppendPlaceHolder(optState.Child, placeholder + '-');
					case StateType.Literal:
						return AppendPlaceHolder(optState.Child, placeholder + 'a');
					case StateType.Numeric:
						return AppendPlaceHolder(optState.Child, placeholder + '0');
					default:
						break;
				}
			}

            if (state is ValueState)
            {
                var optState = state as ValueState;
                switch (optState.Type)
                {
                    case StateType.AlphaNumeric:
                        return AppendPlaceHolder(optState.Child, placeholder + '-');
                    case StateType.Literal:
						return AppendPlaceHolder(optState.Child, placeholder + 'a');
                    case StateType.Numeric:
						return AppendPlaceHolder(optState.Child, placeholder + '0');
                    default:
                        break;
                }
            }

            return placeholder;
        }

        public bool NoMandatoryCharactersLeftAfterState(State state)
        {
            if (state is EOLState)
                return true;
            else if (state is FixedState || state is FreeState || state is ValueState)
                return false;
            else
                return NoMandatoryCharactersLeftAfterState(state.NextState());
        }

		public virtual string DebugDescription()
		{
            return initialState.DebugDescription();
		}
    }
}
