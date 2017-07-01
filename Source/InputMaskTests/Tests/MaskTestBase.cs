
using System;
using InputMask.Classes;
using NUnit.Framework;

namespace InputMaskTests.Tests
{
    public abstract class MaskTestBase
    {
        public Mask CreateMask()
        {
            return new Mask(Format);
        }

        public virtual string Format
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
