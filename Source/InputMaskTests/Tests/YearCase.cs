using System;
using InputMask.Classes.Model;
using NUnit.Framework;

namespace InputMaskTests.Tests
{
    [TestFixture]
    public class YearCase : MaskTestBase
    {
        public override string Format => "[0099]";

        [Test]
        public void TestInit_correctFormat_maskInitialized()
        {
            Assert.NotNull(CreateMask());
        }

        [Test]
        public void TestGetPlaceholder_allSet_returnsCorrectPlaceholder()
        {
            var placeholder = CreateMask().Placeholder();
            Assert.AreEqual(placeholder, "0000");
        }

        [Test]
        public void TestAcceptableTextLength_allSet_returnsCorrectCount()
        {
            var acceptableTextLength = CreateMask().AcceptableTextLength();
            Assert.AreEqual(acceptableTextLength, 2);
        }

        [Test]
        public void TestTotalTextLength_allSet_returnsCorrectCount()
        {
            var totalTextLength = CreateMask().TotalTextLength();
            Assert.AreEqual(totalTextLength, 4);
        }

        [Test]
        public void TestAcceptableValueLength_allSet_returnsCorrectCount()
        {
            var acceptableValueLength = CreateMask().AcceptableValueLength();
            Assert.AreEqual(acceptableValueLength, 2);
        }

        [Test]
        public void TestTotalValueLength_allSet_returnsCorrectCount()
        {
            var totalValueLength = CreateMask().TotalValueLength();
            Assert.AreEqual(totalValueLength, 4);
        }

        [Test]
        public void TestApply_1_returns_1()
        {
            var inputString = "1";
            var inputCaret = inputString.Length;

            var expectedString = "1";
            var expectedCaret = inputString.Length;

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
            var expectedCaret = inputString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApply_112_returns_112()
        {
            var inputString = "112";
            var inputCaret = inputString.Length;

            var expectedString = "112";
            var expectedCaret = inputString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApply_1122_returns_1122()
        {
            var inputString = "1122";
            var inputCaret = inputString.Length;


            var expectedString = "1122";
            var expectedCaret = inputString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }
    }
}
