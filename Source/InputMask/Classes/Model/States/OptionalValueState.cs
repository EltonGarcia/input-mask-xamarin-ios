using System;
using static InputMask.Classes.Model.States.ValueState;

namespace InputMask.Classes.Model.States
{
    public class OptionalValueState : State
    {
		public StateType Type;

		public OptionalValueState(State child, StateType type) : base(child)
        {
            Type = type;
        }

        public override Next Accept(char character)
		{
			if (Accepts(character))
			{
				return new Next(NextState(), character, true, character);
			}
			return new Next(NextState(), null, false, null);
		}

		public Boolean Accepts(char character)
		{
			switch (Type)
			{
				case StateType.Numeric:
					return Char.IsNumber(character);
				case StateType.Literal:
					return Char.IsLetter(character);
				case StateType.AlphaNumeric:
					return Char.IsLetterOrDigit(character);
				default:
					return false;
			}
		}

        public override string DebugDescription()
        {
			var content = Child != null ? Child.DebugDescription() : "null";
			switch (Type)
			{
				case StateType.Numeric:
					return string.Format("[9] -> {0}", content);
				case StateType.Literal:
					return string.Format("[a] -> {0}", content);
				case StateType.AlphaNumeric:
					return string.Format("[-] -> {0}", content);
				default:
					return "null";
			}
        }
    }
}