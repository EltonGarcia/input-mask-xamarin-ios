using InputMaskTests.Tests;
using NUnit.Framework;

namespace InputMaskTests.Tests
{
    [TestFixture]
    public class DayMonthYearCase : MaskTestBase
    {
        public override string Format => "[00]{.}[00]{.}[0000]";

        [Test]
        public void TestInit_correctFormat_maskInitialized()
        {
            Assert.IsNotNull(CreateMask());
        }

        [Test]
        public void TestGetPlaceholder_allSet_returnsCorrectPlaceholder()
        {
            var placeholder = CreateMask().Placeholder();
            Assert.AreEqual(placeholder, "00.00.0000");
        }

        [Test]
        public void TestAcceptableTextLength_allSet_returnsCorrectCount()
        {
            var acceptableTextLength = CreateMask().AcceptableTextLength();
            Assert.AreEqual(acceptableTextLength, 10);
        }

        [Test]
        public void TestTotalTextLength_allSet_returnsCorrectCount()
        {
            var totalTextLength = CreateMask().TotalTextLength();
            Assert.AreEqual(totalTextLength, 10);
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
        public void TestApply_1_returns_1()
        {
            var inputString = "1";
            var inputCaret = inputString.Length;


            var expectedString = "1";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }

        [Test]
        public void TestApply_11_returns_11()
        {
            var inputString = "11";
            var inputCaret = inputString.Length;


            var expectedString = "11";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }

        [Test]
        public void TestApply_111_returns_11dot1()
        {
            var inputString = "111";
            var inputCaret = inputString.Length;


            var expectedString = "11.1";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }

        [Test]
        public void TestApply_1111_returns_11dot11()
        {
            var inputString = "1111";
            var inputCaret = inputString.Length;


            var expectedString = "11.11";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }

        [Test]
        public void TestApply_123456_returns_12dot34dot56()
        {
            var inputString = "123456";
            var inputCaret = inputString.Length;


            var expectedString = "12.34.56";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }

        [Test]
        public void TestApply_12dot3_returns_12dot3()
        {
            var inputString = "12.3";
            var inputCaret = inputString.Length;


            var expectedString = "12.3";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }

        [Test]
        public void TestApply_12dot34_returns_12dot34()
        {
            var inputString = "12.34";
            var inputCaret = inputString.Length;


            var expectedString = "12.34";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }

        [Test]
        public void TestApply_12dot34dot5_returns_12dot34dot5()
        {
            var inputString = "12.34.5";
            var inputCaret = inputString.Length;


            var expectedString = "12.34.5";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_12dot34dot56_returns_12dot34dot56()
        {
            var inputString = "12.34.56";
            var inputCaret = inputString.Length;


            var expectedString = "12.34.56";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }

        [Test]
        public void TestApply_1234567_returns_12dot34dot567()
        {
            var inputString = "1234567";
            var inputCaret = inputString.Length;

            var expectedString = "12.34.567";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_12345678_returns_12dot34dot5678()
        {
            var inputString = "12345678";
            var inputCaret = inputString.Length;


            var expectedString = "12.34.5678";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;


            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApply_1111_StartIndex_returns_11dot11_StartIndex()
        {
            var inputString = "1111";
            var inputCaret = 0;


            var expectedString = "11.11";
            var expectedCaret = 0;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_1111_ThirdIndex_returns_11dot11_FourthIndex()
        {
            var inputString = "1111";

            var inputCaret = 3;


            var expectedString = "11.11";
            var expectedCaret = 4;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_abc1111_returns_11dot11()
        {
            var inputString = "abc1111";
            var inputCaret = inputString.Length;


            var expectedString = "11.11";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_abc1de111_returns_11dot11()
        {
            var inputString = "abc1de111";
            var inputCaret = inputString.Length;


            var expectedString = "11.11";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_abc1de1fg11_returns_11dot11()
        {
            var inputString = "abc1de1fg11";
            var inputCaret = inputString.Length;


            var expectedString = "11.11";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_empty_returns_empty()
        {
            var inputString = "";
            var inputCaret = inputString.Length;


            var expectedString = "";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_1_returns_1()
        {
            var inputString = "1";
            var inputCaret = inputString.Length;

            var expectedString = "1";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_11_returns_11dot()
        {
            var inputString = "11";
            var inputCaret = inputString.Length;

            var expectedString = "11.";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_111_returns_11dot1()
        {
            var inputString = "111";
            var inputCaret = inputString.Length;

            var expectedString = "11.1";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_1111_returns_11dot11dot()
        {
            var inputString = "1111";
            var inputCaret = inputString.Length;

            var expectedString = "11.11.";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_11111_returns_11dot11dot1()
        {
            var inputString = "11111";
            var inputCaret = inputString.Length;

            var expectedString = "11.11.1";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_111111_returns_11dot11dot11()
        {
            var inputString = "111111";
            var inputCaret = inputString.Length;

            var expectedString = "11.11.11";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_1111111_returns_11dot11dot111()
        {
            var inputString = "1111111";
            var inputCaret = inputString.Length;

            var expectedString = "11.11.111";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_11111111_returns_11dot11dot1111()
        {
            var inputString = "11111111";
            var inputCaret = inputString.Length;

            var expectedString = "11.11.1111";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_111111111_returns_11dot11dot1111()
        {
            var inputString = "111111111";
            var inputCaret = inputString.Length;

            var expectedString = "11.11.1111";
            var expectedCaret = expectedString.Length;
            var expectedValue = expectedString;

            var result = CreateMask().Apply(new InputMask.Classes.Model.CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }
    }
}