using System;
using InputMask.Classes.Model;

namespace InputMask.Classes.Helper
{
    public class CaretStringIterator
    {
        private CaretString _caretString;
        private int _currentIndex;

        public CaretStringIterator(CaretString caretString)
        {
            _caretString = caretString;
            _currentIndex = 0;
        }

        public bool BeforeCaret(){
            return _currentIndex <= _caretString.CaretPosition || (_currentIndex == 0 && _caretString.CaretPosition == 0);
        }

        public char? Next()
        {
            if (_currentIndex >= _caretString.Content.Length)
                return null;

            var character = _caretString.Content[_currentIndex];
            _currentIndex = ++_currentIndex;
            return character;
        }
    }
}
