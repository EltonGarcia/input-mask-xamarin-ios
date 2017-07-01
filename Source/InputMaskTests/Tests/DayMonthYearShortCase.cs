using System;
using InputMask.Classes.Model;
using NUnit.Framework;

namespace InputMaskTests.Tests
{
    [TestFixture]
    public class DayMonthYearShortCase : MaskTestBase
    {
        public override string Format => "[90]{.}[90]{.}[0000]";

        [Test]
        public void testInit_correctFormat_maskInitialized()
        {
            Assert.NotNull(CreateMask());
        }

        [Test]
        public void testGetPlaceholder_allSet_returnsCorrectPlaceholder()
        {
            var placeholder = CreateMask().Placeholder();
            Assert.AreEqual(placeholder, "00.00.0000");
        }

        [Test]
        public void testAcceptableTextLength_allSet_returnsCorrectCount()
        {
            var acceptableTextLength = CreateMask().AcceptableTextLength();
            Assert.AreEqual(acceptableTextLength, 8);
        }

        [Test]
        public void testTotalTextLength_allSet_returnsCorrectCount()
        {
            var totalTextLength = CreateMask().TotalTextLength();
            Assert.AreEqual(totalTextLength, 10);
        }

        [Test]
        public void testAcceptableValueLength_allSet_returnsCorrectCount()
        {
            var acceptableValueLength = CreateMask().AcceptableValueLength();
            Assert.AreEqual(acceptableValueLength, 8);
        }

        [Test]
        public void testTotalValueLength_allSet_returnsCorrectCount()
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

            var expectedValue = "1";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content); Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition); Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(1, result.Affinity); Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_11_returns_11()
        {
            var inputString = "11";
            var inputCaret = inputString.Length;

            var expectedString = "11";
            var expectedCaret = expectedString.Length;

            var expectedValue = "11";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition); Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(2, result.Affinity); Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_111_returns_11dot1()
        {
            var inputString = "111";
            var inputCaret = inputString.Length;

            var expectedString = "11.1";
            var expectedCaret = expectedString.Length;

            var expectedValue = "11.1";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(2, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_1111_returns_11dot11()
        {
            var inputString = "1111";
            var inputCaret = inputString.Length;

            var expectedString = "11.11";
            var expectedCaret = expectedString.Length;

            var expectedValue = "11.11";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(3, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_123456_returns_12dot34dot56()
        {
            var inputString = "123456";
            var inputCaret = inputString.Length;

            var expectedString = "12.34.56";
            var expectedCaret = expectedString.Length;

            var expectedValue = "12.34.56";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(4, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_12dot3_returns_12dot3()
        {
            var inputString = "12.3";
            var inputCaret = inputString.Length;

            var expectedString = "12.3";
            var expectedCaret = expectedString.Length;

            var expectedValue = "12.3";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(4, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_12dot34_returns_12dot34()
        {
            var inputString = "12.34";
            var inputCaret = inputString.Length;

            var expectedString = "12.34";
            var expectedCaret = expectedString.Length;

            var expectedValue = "12.34";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(5, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_12dot34dot5_returns_12dot34dot5()
        {
            var inputString = "12.34.5";
            var inputCaret = inputString.Length;

            var expectedString = "12.34.5";
            var expectedCaret = expectedString.Length;

            var expectedValue = "12.34.5";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(7, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_12dot34dot56_returns_12dot34dot56()
        {
            var inputString = "12.34.56";
            var inputCaret = inputString.Length;

            var expectedString = "12.34.56";
            var expectedCaret = expectedString.Length;

            var expectedValue = "12.34.56";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(8, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_1234567_returns_12dot34dot567()
        {
            var inputString = "1234567";
            var inputCaret = inputString.Length;

            var expectedString = "12.34.567";
            var expectedCaret = expectedString.Length;

            var expectedValue = "12.34.567";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(5, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_12345678_returns_12dot34dot5678()
        {
            var inputString = "12345678";
            var inputCaret = inputString.Length;


            var expectedString = "12.34.5678";
            var expectedCaret = expectedString.Length;

            var expectedValue = "12.34.5678";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(6, result.Affinity);
            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApply_1111_StartIndex_returns_11dot11_StartIndex()
        {
            var inputString = "1111";
            var inputCaret = 0;

            var expectedString = "11.11";
            var expectedCaret = 0;

            var expectedValue = "11.11";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(3, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_1111_ThirdIndex_returns_11dot11_FourthIndex()
        {
            var inputString = "1111";
            var inputCaret = 3;

            var expectedString = "11.11";
            var expectedCaret = 4;

            var expectedValue = "11.11";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(3, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_abc1111_returns_11dot11()
        {
            var inputString = "abc1111";
            var inputCaret = inputString.Length;

            var expectedString = "11.11";
            var expectedCaret = expectedString.Length;

            var expectedValue = "11.11";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(0, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_abc1de111_returns_11dot11()
        {
            var inputString = "abc1de111";
            var inputCaret = inputString.Length;

            var expectedString = "1.11.1";
            var expectedCaret = expectedString.Length;

            var expectedValue = "1.11.1";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(-4, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_abc1de1fg11_returns_11dot11()
        {
            var inputString = "abc1de1fg11";
            var inputCaret = inputString.Length;

            var expectedString = "1.1.11";
            var expectedCaret = expectedString.Length;

            var expectedValue = "1.1.11";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(-7, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_a_returns_empty()
        {
            var inputString = "a";
            var inputCaret = inputString.Length;

            var expectedString = "";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(-1, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_empty_returns_empty()
        {
            var inputString = "";
            var inputCaret = inputString.Length;

            var expectedString = "";
            var expectedCaret = expectedString.Length;

            var expectedValue = "";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(0, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_1_returns_1()
        {
            var inputString = "1";
            var inputCaret = inputString.Length;

            var expectedString = "1";
            var expectedCaret = expectedString.Length;

            var expectedValue = "1";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(1, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_11_returns_11dot()
        {
            var inputString = "11";
            var inputCaret = inputString.Length;

            var expectedString = "11.";
            var expectedCaret = expectedString.Length;

            var expectedValue = "11.";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(2, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_112_returns_11dot2()
        {
            var inputString = "112";
            var inputCaret = inputString.Length;

            var expectedString = "11.2";
            var expectedCaret = expectedString.Length;

            var expectedValue = "11.2";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(2, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_1122_returns_11dot22dot()
        {
            var inputString = "1122";
            var inputCaret = inputString.Length;

            var expectedString = "11.22.";
            var expectedCaret = expectedString.Length;

            var expectedValue = "11.22.";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(3, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_11223_returns_11dot22dot3()
        {
            var inputString = "11223";
            var inputCaret = inputString.Length;

            var expectedString = "11.22.3";
            var expectedCaret = expectedString.Length;

            var expectedValue = "11.22.3";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(3, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_112233_returns_11dot22dot33()
        {
            var inputString = "112233";
            var inputCaret = inputString.Length;

            var expectedString = "11.22.33";
            var expectedCaret = expectedString.Length;

            var expectedValue = "11.22.33";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(4, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_1122333_returns_11dot22dot333()
        {
            var inputString = "1122333";
            var inputCaret = inputString.Length;

            var expectedString = "11.22.333";
            var expectedCaret = expectedString.Length;

            var expectedValue = "11.22.333";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(5, result.Affinity);
            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_11223333_returns_11dot22dot3333()
        {
            var inputString = "11223333";
            var inputCaret = inputString.Length;

            var expectedString = "11.22.3333";
            var expectedCaret = expectedString.Length;

            var expectedValue = "11.22.3333";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(6, result.Affinity);
            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_112233334_returns_11dot22dot3333()
        {
            var inputString = "112233334";
            var inputCaret = inputString.Length;

            var expectedString = "11.22.3333";
            var expectedCaret = expectedString.Length;

            var expectedValue = "11.22.3333";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(5, result.Affinity);
            Assert.AreEqual(true, result.Complete);
        }
    }
}