using System;
namespace InputMask.Classes.Model.States
{
    public class FreeState : State
    {
        public char OwnCharacter;

        public FreeState(State child, char character) : base(child)
        {
            Child = child;
            OwnCharacter = character;
        }

        public override Next Accept(char character)
        {
            if (OwnCharacter == character)
            {
                return new Next(NextState(), character, true, null);
            }

            return new Next(NextState(), OwnCharacter, false, null);
        }

        public override Next Autocomplete()
        {
            return new Next(NextState(), OwnCharacter, false, null);
        }

		public override string DebugDescription()
		{
			return string.Format("{0} -> {1}", OwnCharacter, Child != null ? Child.DebugDescription() : "null");
		}
    }
}
