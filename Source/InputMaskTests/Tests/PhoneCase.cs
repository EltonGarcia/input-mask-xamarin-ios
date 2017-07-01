using System;
using InputMask.Classes.Model;
using NUnit.Framework;

namespace InputMaskTests.Tests
{
    [TestFixture]
    public class PhoneCase : MaskTestBase
    {
        public override string Format => "+7 ([000]) [000] [00] [00]";

        [Test]
        public void TestInit_correctFormat_maskInitialized()
        {
            Assert.NotNull(CreateMask());
        }

        [Test]
        public void TestGetPlaceholder_allSet_returnsCorrectPlaceholder()
        {
            var placeholder = CreateMask().Placeholder();

            Assert.AreEqual(placeholder, "+7 (000) 000 00 00");
        }

        [Test]
        public void TestAcceptableTextLength_allSet_returnsCorrectCount()
        {
            var acceptableTextLength = CreateMask().AcceptableTextLength();
            Assert.AreEqual(acceptableTextLength, 18);
        }


        [Test]
        public void TestTotalTextLength_allSet_returnsCorrectCount()
        {
            var totalTextLength = CreateMask().TotalTextLength();
            Assert.AreEqual(totalTextLength, 18);
        }


        [Test]
        public void TestAcceptableValueLength_allSet_returnsCorrectCount()
        {
            var acceptableValueLength = CreateMask().AcceptableValueLength();
            Assert.AreEqual(acceptableValueLength, 10);
        }


        [Test]
        public void TestTotalValueLength_allSet_returnsCorrectCount()
        {
            var totalValueLength = CreateMask().TotalValueLength();

            Assert.AreEqual(totalValueLength, 10);
        }


        [Test]
        public void TestApply_plus_return_plus()
        {
            var inputString = "+";
            var inputCaret = inputString.Length;

            var expectedString = "+";
            var expectedCaret = expectedString.Length;

            var expectedValue = "";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7_return_plus7()
        {
            var inputString = "+7";
            var inputCaret = inputString.Length;

            var expectedString = "+7";
            var expectedCaret = expectedString.Length;

            var expectedValue = "";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7space_return_plus7space()
        {
            var inputString = "+7 ";
            var inputCaret = inputString.Length;

            var expectedString = "+7 ";
            var expectedCaret = expectedString.Length;

            var expectedValue = "";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace_return_plus7spaceBrace()
        {
            var inputString = "+7 (";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (";
            var expectedCaret = expectedString.Length;

            var expectedValue = "";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace1_return_plus7spaceBrace1()
        {
            var inputString = "+7 (1";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (1";
            var expectedCaret = expectedString.Length;

            var expectedValue = "1";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace12_return_plus7spaceBrace12()
        {
            var inputString = "+7 (12";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (12";
            var expectedCaret = expectedString.Length;

            var expectedValue = "12";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace123_return_plus7spaceBrace123()
        {
            var inputString = "+7 (123";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123";
            var expectedCaret = expectedString.Length;

            var expectedValue = "123";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace123brace_return_plus7spaceBrace123brace()
        {
            var inputString = "+7 (123)";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123)";
            var expectedCaret = expectedString.Length;

            var expectedValue = "123";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace123braceSpace_return_plus7spaceBrace123braceSpace()
        {
            var inputString = "+7 (123) ";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123) ";
            var expectedCaret = expectedString.Length;

            var expectedValue = "123";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace123braceSpace4_return_plus7spaceBrace123braceSpace4()
        {
            var inputString = "+7 (123) 4";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123) 4";
            var expectedCaret = expectedString.Length;

            var expectedValue = "1234";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace123braceSpace45_return_plus7spaceBrace123braceSpace45()
        {
            var inputString = "+7 (123) 45";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123) 45";
            var expectedCaret = expectedString.Length;

            var expectedValue = "12345";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace123braceSpace456_return_plus7spaceBrace123braceSpace456()
        {
            var inputString = "+7 (123) 456";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123) 456";
            var expectedCaret = expectedString.Length;

            var expectedValue = "123456";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace123braceSpace456space_return_plus7spaceBrace123braceSpace456space()
        {
            var inputString = "+7 (123) 456 ";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123) 456 ";
            var expectedCaret = expectedString.Length;

            var expectedValue = "123456";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace123braceSpace456space7_return_plus7spaceBrace123braceSpace456space7()
        {
            var inputString = "+7 (123) 456 7";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123) 456 7";
            var expectedCaret = expectedString.Length;

            var expectedValue = "1234567";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace123braceSpace456space78_return_plus7spaceBrace123braceSpace456space78()
        {
            var inputString = "+7 (123) 456 78";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123) 456 78";
            var expectedCaret = expectedString.Length;

            var expectedValue = "12345678";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace123braceSpace456space78space_return_plus7spaceBrace123braceSpace456space78space()
        {
            var inputString = "+7 (123) 456 78 ";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123) 456 78 ";
            var expectedCaret = expectedString.Length;

            var expectedValue = "12345678";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace123braceSpace456space78space9_return_plus7spaceBrace123braceSpace456space78space9()
        {
            var inputString = "+7 (123) 456 78 9";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123) 456 78 9";
            var expectedCaret = expectedString.Length;

            var expectedValue = "123456789";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_plus7spaceBrace123braceSpace456space78space90_return_plus7spaceBrace123braceSpace456space78space90()
        {
            var inputString = "+7 (123) 456 78 90";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123) 456 78 90";
            var expectedCaret = expectedString.Length;

            var expectedValue = "1234567890";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApply_7_return_plus7()
        {
            var inputString = "7";
            var inputCaret = inputString.Length;

            var expectedString = "+7";
            var expectedCaret = expectedString.Length;

            var expectedValue = "";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_9_return_plus7spaceBrace9()
        {
            var inputString = "9";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (9";
            var expectedCaret = expectedString.Length;

            var expectedValue = "9";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_1234567890_return_plus7spaceBrace123braceSpace456space78space90()
        {
            var inputString = "1234567890";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123) 456 78 90";
            var expectedCaret = expectedString.Length;

            var expectedValue = "1234567890";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApply_12345678901_return_plus7spaceBrace123braceSpace456space78space90()
        {
            var inputString = "12345678901";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123) 456 78 90";
            var expectedCaret = expectedString.Length;

            var expectedValue = "1234567890";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApply_plus1234567890_return_plus7spaceBrace123braceSpace456space78space90()
        {
            var inputString = "+1234567890";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123) 456 78 90";
            var expectedCaret = expectedString.Length;

            var expectedValue = "1234567890";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApply_plusBrace123brace456dash78dash90_return_plus7spaceBrace123braceSpace456space78space90()
        {
            var inputString = "+(123)456-78-90";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (123) 456 78 90";
            var expectedCaret = expectedString.Length;

            var expectedValue = "1234567890";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_empty_return_plus7spaceBrace()
        {
            var inputString = "";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (";
            var expectedCaret = expectedString.Length;

            var expectedValue = "";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_plus_return_plus7spaceBrace()
        {
            var inputString = "+";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (";
            var expectedCaret = expectedString.Length;

            var expectedValue = "";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_plus7_return_plus7spaceBrace()
        {
            var inputString = "+7";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (";
            var expectedCaret = expectedString.Length;

            var expectedValue = "";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_plus7space_return_plus7spaceBrace()
        {
            var inputString = "+7 ";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (";
            var expectedCaret = expectedString.Length;

            var expectedValue = "";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_plus7spaceBrace_return_plus7spaceBrace()
        {
            var inputString = "+7 (";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (";
            var expectedCaret = expectedString.Length;

            var expectedValue = "";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_a_return_plus7spaceBrace()
        {
            var inputString = "a";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (";
            var expectedCaret = expectedString.Length;

            var expectedValue = "";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_aPlus7spaceBrace_return_plus7spaceBrace()
        {
            var inputString = "a+7 (";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (7";
            var expectedCaret = expectedString.Length;

            var expectedValue = "7";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_7space_return_plus7spaceBrace()
        {
            var inputString = "7 ";
            var inputCaret = inputString.Length;

            var expectedString = "+7 (";
            var expectedCaret = expectedString.Length;

            var expectedValue = "";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }
    }
}