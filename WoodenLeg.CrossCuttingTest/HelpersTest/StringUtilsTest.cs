using WoodenLeg.CrossCutting.Helpers;
using Xunit;

namespace WoodenLeg.CrossCuttingTest.HelpersTest
{
    public class StringUtilsTest
    {
        #region [Methods]

        [Fact]
        public void HasValueTrueTest()
        {
            string _test = "This string has value";

            Assert.True( _test.HasValue(), "The string should have value" );
        }

        [Fact]
        public void HasValueFalseTest()
        {
            string _test = string.Empty;
            string _testeNull = null;

            Assert.False( _test.HasValue() );
            Assert.False( _testeNull.HasValue() );
        }

        #endregion
    }
}
