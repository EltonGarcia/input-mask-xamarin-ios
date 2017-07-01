using System;
namespace InputMask.Classes.Model.States
{
    public class FixedState : State
    {
        public char OwnCharacter;

        public FixedState(State child, char character) : base(child)
        {
            OwnCharacter = character;
        }

        public override Next Accept(char character)
        {
            if (OwnCharacter == character)
                return new Next(NextState(), character, true, character);
            
			return new Next(NextState(), OwnCharacter, false, OwnCharacter);
		}

        public override Next Autocomplete()
        {
            return new Next(NextState(), OwnCharacter, false, OwnCharacter);
        }

        public override string DebugDescription()
        {
            return string.Format("{0} -> {1}", OwnCharacter, Child != null ? Child.DebugDescription() : "null");
        }
    }
}
