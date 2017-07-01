using System;
using InputMask.Classes.Model;
using NUnit.Framework;

namespace InputMaskTests.Tests
{
    [TestFixture]
    public class MonthYearDoubledoubleShashCase : MaskTestBase
    {
        public override string Format => "[00]{//}[0000]";

        [Test]
        public void TestInit_correctFormat_maskInitialized()
        {
            Assert.NotNull(CreateMask());
        }

        [Test]
        public void TestGetPlaceholder_allSet_returnsCorrectPlaceholder()
        {
            var placeholder = CreateMask().Placeholder();

            Assert.AreEqual(placeholder, "00//0000");
        }


        [Test]
        public void TestAcceptableTextLength_allSet_returnsCorrectCount()
        {
            var acceptableTextLength = CreateMask().AcceptableTextLength();

            Assert.AreEqual(acceptableTextLength, 8);
        }


        [Test]
        public void TestTotalTextLength_allSet_returnsCorrectCount()
        {
            var totalTextLength = CreateMask().TotalTextLength();

            Assert.AreEqual(totalTextLength, 8);

        }


        [Test]
        public void TestAcceptableValueLength_allSet_returnsCorrectCount()
        {
            var acceptableValueLength = CreateMask().AcceptableValueLength();

            Assert.AreEqual(acceptableValueLength, 8);
        }


        [Test]
        public void TestTotalValueLength_allSet_returnsCorrectCount()
        {
            var totalValueLength = CreateMask().TotalValueLength();

            Assert.AreEqual(totalValueLength, 8);
        }


        [Test]
        public void TestApply_1_returns_1()
        {
            var inputString = "1";
            var inputCaret = inputString.Length;


            var expectedString = "1";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

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

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_111_returns_11doubleShash1()
        {
            var inputString = "111";
            var inputCaret = inputString.Length;

            var expectedString = "11//1";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_1111_returns_11doubleShash11()
        {
            var inputString = "1111";
            var inputCaret = inputString.Length;

            var expectedString = "11//11";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_123456_returns_12doubleShash3456()
        {
            var inputString = "123456";
            var inputCaret = inputString.Length;


            var expectedString = "12//3456";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApply_12shash3_returns_12doubleShash3()
        {
            var inputString = "12/3";
            var inputCaret = inputString.Length;

            var expectedString = "12//3";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_12doubleShash3_returns_12doubleShash3()
        {
            var inputString = "12//3";
            var inputCaret = inputString.Length;

            var expectedString = "12//3";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_12shash34_returns_12doubleShash34()
        {
            var inputString = "12/34";
            var inputCaret = inputString.Length;

            var expectedString = "12//34";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_12doubleShash34_returns_12doubleShash34()
        {
            var inputString = "12//34";
            var inputCaret = inputString.Length;

            var expectedString = "12//34";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_12doubleShash345_returns_12doubleShash345()
        {
            var inputString = "12//345";
            var inputCaret = inputString.Length;

            var expectedString = "12//345";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_12doubleShash3456_returns_12doubleShash3456()
        {
            var inputString = "12//3456";
            var inputCaret = inputString.Length;

            var expectedString = "12//3456";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApply_1234567_returns_12doubleShash3456()
        {
            var inputString = "1234567";
            var inputCaret = inputString.Length;

            var expectedString = "12//3456";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApply_12345678_returns_12doubleShash3456()
        {
            var inputString = "12345678";
            var inputCaret = inputString.Length;

            var expectedString = "12//3456";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApply_1111_StartIndex_returns_11doubleShash11_StartIndex()
        {
            var inputString = "1111";
            var inputCaret = 0;

            var expectedString = "11//11";
            var expectedCaret = 0;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_1111_ThirdIndex_returns_11doubleShash11_FourthIndex()
        {
            var inputString = "1111";
            var inputCaret = 3;

            var expectedString = "11//11";
            var expectedCaret = 5;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_abc1111_returns_11doubleShash11()
        {
            var inputString = "abc1111";
            var inputCaret = inputString.Length;

            var expectedString = "11//11";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_abc1de111_returns_11doubleShash11()
        {
            var inputString = "abc1de111";
            var inputCaret = inputString.Length;

            var expectedString = "11//11";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_abc1de1fg11_returns_11doubleShash11()
        {
            var inputString = "abc1de1fg11";
            var inputCaret = inputString.Length;

            var expectedString = "11//11";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }

    }
}
