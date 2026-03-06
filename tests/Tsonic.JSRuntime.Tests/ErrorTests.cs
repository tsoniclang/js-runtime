using Xunit;

namespace Tsonic.JSRuntime.Tests
{
    public class ErrorTests
    {
        [Fact]
        public void constructor_WithMessage_ExposesLowercaseMessage()
        {
            var error = new Error("boom");

            Assert.Equal("boom", error.message);
            Assert.Equal("Error", error.name);
        }

        [Fact]
        public void constructor_IsException()
        {
            var error = new Error("boom");

            Assert.IsAssignableFrom<System.Exception>(error);
        }
    }
}
