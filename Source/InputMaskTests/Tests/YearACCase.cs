using System;
using InputMask.Classes.Model;
using NUnit.Framework;

namespace InputMaskTests.Tests
{
    [TestFixture]
    public class YearACCase : MaskTestBase
    {
        public override string Format => "[9990] AC";

        [Test]
        public void TestInit_correctFormat_maskInitialized()
        {
            Assert.NotNull(CreateMask());
        }

        [Test]
        public void TestGetPlaceholder_allSet_returnsCorrectPlaceholder()
        {
            var placeholder = CreateMask().Placeholder();

            Assert.AreEqual(placeholder, "0000 AC");
        }

        [Test]
        public void TestAcceptableTextLength_allSet_returnsCorrectCount()
        {
            var acceptableTextLength = CreateMask().AcceptableTextLength();

            Assert.AreEqual(acceptableTextLength, 4);
        }

        [Test]
        public void TestTotalTextLength_allSet_returnsCorrectCount()
        {
            var totalTextLength = CreateMask().TotalTextLength();

            Assert.AreEqual(totalTextLength, 7);
        }

        [Test]
        public void TestAcceptableValueLength_allSet_returnsCorrectCount()
        {
            var acceptableValueLength = CreateMask().AcceptableValueLength();

            Assert.AreEqual(acceptableValueLength, 1);
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
        public void TestApply_111_returns_111()
        {
            var inputString = "111";
            var inputCaret = inputString.Length;

            var expectedString = "111";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }

        [Test]
        public void TestApply_1111_returns_1111()
        {
            var inputString = "1111";
            var inputCaret = inputString.Length;

            var expectedString = "1111";
            var expectedCaret = expectedString.Length;

            var expectedValue = expectedString;

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(false, result.Complete);
        }


        [Test]
        public void TestApply_11112_returns_1111spaceAC()
        {
            var inputString = "11112";
            var inputCaret = inputString.Length;

            var expectedString = "1111 AC";
            var expectedCaret = expectedString.Length;

            var expectedValue = "1111";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret));

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }


        [Test]
        public void TestApplyAutocomplete_1111_returns_1111spaceAC()
        {
            var inputString = "1111";
            var inputCaret = inputString.Length;

            var expectedString = "1111 AC";
            var expectedCaret = expectedString.Length;

            var expectedValue = "1111";

            var result = CreateMask().Apply(new CaretString(inputString, inputCaret), true);

            Assert.AreEqual(expectedString, result.FormattedText.Content);
            Assert.AreEqual(expectedCaret, result.FormattedText.CaretPosition);
            Assert.AreEqual(expectedValue, result.ExtractedValue);

            Assert.AreEqual(true, result.Complete);
        }
    }
}