
using System;
using InputMask.Classes;
using InputMask.Classes.Model;
using NUnit.Framework;

namespace InputMaskTests.Tests
{
    [TestFixture]
    public class MaskTestCase
    {
        [Test]
        public void TestInit_nestedBrackets_throwsWrongFormatCompilerError()
        {
            Assert.Throws<WrongFormatException>(() => {
				new Mask("[[00]000]");
			});
        }

		[Test]
		public void TestInit_mixedCharacters_initialized()
		{
			var mask = new Mask("[00000Aa]");
            Assert.IsNotNull(mask);
		}
    }
}
