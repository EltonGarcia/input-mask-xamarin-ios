using System;
namespace InputMask.Classes.Model.States
{
    public class EOLState : State
    {
        public EOLState(State child) : base(child)
        {
        }

        public EOLState() : base(null)
        {
        }

        public override Next Accept(char character)
        {
            return null;
        }

        public override State NextState()
        {
            return this;
        }

        public override string DebugDescription()
        {
            return "EOL";
        }
    }
}
