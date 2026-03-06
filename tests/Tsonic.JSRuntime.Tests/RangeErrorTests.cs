using Xunit;

namespace Tsonic.JSRuntime.Tests
{
    public class RangeErrorTests
    {
        [Fact]
        public void constructor_WithMessage_PreservesMessage()
        {
            var error = new RangeError("out of range");

            Assert.Equal("out of range", error.Message);
            Assert.Equal("out of range", error.message);
            Assert.Equal("RangeError", error.name);
        }

        [Fact]
        public void constructor_IsException()
        {
            var error = new RangeError("boom");

            Assert.IsAssignableFrom<System.Exception>(error);
        }
    }
}
