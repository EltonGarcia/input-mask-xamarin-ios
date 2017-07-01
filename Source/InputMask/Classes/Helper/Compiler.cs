using System;
using System.Linq;
using Foundation;
using InputMask.Classes.Model;
using InputMask.Classes.Model.States;

namespace InputMask.Classes.Helper
{
    public class Compiler
    {
        public State Compile(string formatString)
        {
            var sanitizedFormat = new FormatSanitizer().Sanitize(formatString);
            return Compile(sanitizedFormat, false, false);
        }

        private State Compile(string content, bool valueable, bool wasFixed)
        {
            if (string.IsNullOrEmpty(content) || content.Length == 0)
                return new EOLState();
            
            var character = content.First();

            if ('[' == character)
                return Compile(content.TruncateFirst(), true, false);

            if ('{' == character)
                return Compile(content.TruncateFirst(), false, true);

			if (']' == character)
                return Compile(content.TruncateFirst(), false, false);

            if ('}' == character)
				return Compile(content.TruncateFirst(), false, false);

            if (valueable)
            {
                if (character == '0')
                    return new ValueState(Compile(content.TruncateFirst(), true, false), ValueState.StateType.Numeric);

				if (character == 'A')
                    return new ValueState(Compile(content.TruncateFirst(), true, false), ValueState.StateType.Literal);

				if (character == '_')
                    return new ValueState(Compile(content.TruncateFirst(), true, false), ValueState.StateType.AlphaNumeric);

				if (character == '9')
                    return new OptionalValueState(Compile(content.TruncateFirst(), true, false), ValueState.StateType.Numeric);

				if (character == 'a')
					return new OptionalValueState(Compile(content.TruncateFirst(), true, false), ValueState.StateType.Literal);

				if (character == '-')
                    return new OptionalValueState(Compile(content.TruncateFirst(), true, false), ValueState.StateType.AlphaNumeric);

                throw new CompilationException();
            }

            if (wasFixed)
                return new FixedState(Compile(content.TruncateFirst(), false, true), character);

            return new FreeState(Compile(content.TruncateFirst(), false, false), character);
        }
    }
}
