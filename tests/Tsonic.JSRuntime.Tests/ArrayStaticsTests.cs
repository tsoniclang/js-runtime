using System.Collections.Generic;
using Xunit;

namespace Tsonic.JSRuntime.Tests
{
    public class ArrayStaticsTests
    {
        [Fact]
        public void from_WithEnumerable_ReturnsArray()
        {
            var result = JSArrayStatics.from(new List<int> { 1, 2, 3 });

            Assert.IsType<int[]>(result);
            Assert.Equal(3, result.Length);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        [Fact]
        public void from_WithMapFunction_ProjectsItems()
        {
            var result = JSArrayStatics.from(
                new List<string> { "a", "b", "c" },
                (value, index) => $"{index}:{value}"
            );

            Assert.IsType<string[]>(result);
            Assert.Equal(3, result.Length);
            Assert.Equal("0:a", result[0]);
            Assert.Equal("1:b", result[1]);
            Assert.Equal("2:c", result[2]);
        }

        [Fact]
        public void from_WithString_ReturnsStringElements()
        {
            var result = JSArrayStatics.from("abc");

            Assert.IsType<string[]>(result);
            Assert.Equal(3, result.Length);
            Assert.Equal("a", result[0]);
            Assert.Equal("b", result[1]);
            Assert.Equal("c", result[2]);
        }

        [Fact]
        public void from_WithStringAndMapFunction_ProjectsStringElements()
        {
            var result = JSArrayStatics.from(
                "abc",
                (value, index) => $"{index}:{value}"
            );

            Assert.IsType<string[]>(result);
            Assert.Equal(3, result.Length);
            Assert.Equal("0:a", result[0]);
            Assert.Equal("1:b", result[1]);
            Assert.Equal("2:c", result[2]);
        }

        [Fact]
        public void of_ReturnsArray()
        {
            var result = JSArrayStatics.of(4, 5, 6);

            Assert.IsType<int[]>(result);
            Assert.Equal(3, result.Length);
            Assert.Equal(4, result[0]);
            Assert.Equal(5, result[1]);
            Assert.Equal(6, result[2]);
        }

        [Fact]
        public void isArray_ReturnsTrue_ForArraysAndJSArray()
        {
            Assert.True(JSArrayStatics.isArray(new[] { 1, 2, 3 }));
            Assert.True(JSArrayStatics.isArray(new JSArray<int>(new[] { 1, 2, 3 })));
            Assert.False(JSArrayStatics.isArray("abc"));
            Assert.False(JSArrayStatics.isArray(null));
        }
    }
}
