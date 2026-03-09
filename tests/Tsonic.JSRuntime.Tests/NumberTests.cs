using Tsonic.JSRuntime;
using Xunit;

namespace Tsonic.JSRuntime.Tests
{
    public class NumberTests
    {
        [Fact]
        public void toString_UsesInvariantFormatting()
        {
            Assert.Equal("42", 42d.toString());
            Assert.Equal("3.5", 3.5d.toString());
            Assert.Equal("7", 7.toString());
            Assert.Equal("9", 9L.toString());
            Assert.Equal("11", ((int?)11).toString());
            Assert.Equal("13", ((long?)13).toString());
            Assert.Equal(string.Empty, ((int?)null).toString());
        }

        [Fact]
        public void valueOf_ReturnsOriginalValue()
        {
            Assert.Equal(42d, 42d.valueOf());
            Assert.Equal(-1.25d, (-1.25d).valueOf());
            Assert.Equal(42, 42.valueOf());
            Assert.Equal(128L, 128L.valueOf());
            Assert.Equal((int?)64, ((int?)64).valueOf());
            Assert.Equal((long?)256, ((long?)256).valueOf());
        }

        [Fact]
        public void Static_Number_Predicates_AcceptIntegralReceivers()
        {
            Assert.False(Number.isNaN(7));
            Assert.False(Number.isNaN((int?)7));
            Assert.False(Number.isNaN(9L));
            Assert.False(Number.isNaN((long?)9));

            Assert.True(Number.isFinite(7));
            Assert.True(Number.isFinite((int?)7));
            Assert.True(Number.isFinite(9L));
            Assert.True(Number.isFinite((long?)9));
            Assert.False(Number.isFinite((int?)null));
            Assert.False(Number.isFinite((long?)null));

            Assert.True(Number.isInteger(7));
            Assert.True(Number.isInteger((int?)7));
            Assert.True(Number.isInteger(9L));
            Assert.True(Number.isInteger((long?)9));
            Assert.False(Number.isInteger((int?)null));
            Assert.False(Number.isInteger((long?)null));

            Assert.True(Number.isSafeInteger(7));
            Assert.True(Number.isSafeInteger((int?)7));
            Assert.True(Number.isSafeInteger(9L));
            Assert.True(Number.isSafeInteger((long?)9));
            Assert.False(Number.isSafeInteger((long?)null));
        }
    }
}
