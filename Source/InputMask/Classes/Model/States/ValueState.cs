using System;
namespace InputMask.Classes.Model.States
{
    public class ValueState : State
    {
		public enum StateType
		{
			Numeric,
			Literal,
			AlphaNumeric
		}

		public StateType Type;

		public ValueState(State child, StateType type) : base(child)
        {
			Type = type;
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

		public override Next Accept(char character)
		{
            if (!Accepts(character))
                return null;
            return new Next(NextState(), character, true, character);
		}

		public override string DebugDescription()
		{
			var content = Child != null ? Child.DebugDescription() : "null";
			switch (Type)
			{
				case StateType.Numeric:
					return string.Format("[0] -> {0}", content);
				case StateType.Literal:
					return string.Format("[A] -> {0}", content);
				case StateType.AlphaNumeric:
					return string.Format("[_] -> {0}", content);
				default:
					return "null";
			}
		}
	}
}
