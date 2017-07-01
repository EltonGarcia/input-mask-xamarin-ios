using System.Diagnostics;

namespace InputMask.Classes.Model
{
    [DebuggerDisplay("{DebugDescription()}")]
    public abstract class State
    {
        public State Child;

        public State(State child)
        {
            Child = child;
        }

        public abstract Next Accept(char character);

        public virtual Next Autocomplete()
        {
            return null;
        }

        public virtual State NextState()
		{
            return Child;
		}

        public virtual string DebugDescription()
        {
            return string.Format("BASE -> {0}", Child != null ? Child.DebugDescription() : "null");
        }
    }
}