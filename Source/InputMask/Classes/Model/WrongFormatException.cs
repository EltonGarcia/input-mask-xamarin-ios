using System;
namespace InputMask.Classes.Model
{
    public class WrongFormatException : Exception
    {
        public WrongFormatException()
        {
        }
        public WrongFormatException(string message) : base(message)
        {
        }
    }
}
