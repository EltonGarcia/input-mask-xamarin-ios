using System;
namespace InputMask.Classes.Model
{
    public class Next
    {
		public State State { get; set; }
        public char? Insert { get; set; }
        public bool Pass { get; set; }
        public char? Value { get; set; }

        public Next()
        {
        }

        public Next(State state, char? insert, bool pass, char? value)
        {
            State = state;
            Insert = insert;
            Pass = pass;
            Value = value;
        }
    }
}
