using System;
namespace InputMask.Classes.Model
{
    public class CaretString
    {
        public String Content;

        public nint CaretPosition;

        public CaretString(String content, nint caretPosition)
        {
            Content = content;
            CaretPosition = caretPosition;
        }
    }
}
