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
        }

        [Fact]
        public void valueOf_ReturnsOriginalValue()
        {
            Assert.Equal(42d, 42d.valueOf());
            Assert.Equal(-1.25d, (-1.25d).valueOf());
        }
    }
}
