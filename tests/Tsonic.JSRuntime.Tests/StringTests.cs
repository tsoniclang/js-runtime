using System.Collections.Generic;
using Tsonic.JSRuntime;
using Xunit;

namespace Tsonic.JSRuntime.Tests
{
    public class StringTests
    {
        [Fact]
        public void toUpperCase_ConvertsToUpperCase()
        {
            Assert.Equal("HELLO", "hello".toUpperCase());
            Assert.Equal("WORLD123", "world123".toUpperCase());
        }

        [Fact]
        public void toLowerCase_ConvertsToLowerCase()
        {
            Assert.Equal("hello", "HELLO".toLowerCase());
            Assert.Equal("world123", "WORLD123".toLowerCase());
        }

        [Fact]
        public void trim_RemovesWhitespace()
        {
            Assert.Equal("hello", "  hello  ".trim());
            Assert.Equal("hello", "\thello\n".trim());
        }

        [Fact]
        public void trimStart_RemovesLeadingWhitespace()
        {
            Assert.Equal("hello  ", "  hello  ".trimStart());
        }

        [Fact]
        public void trimEnd_RemovesTrailingWhitespace()
        {
            Assert.Equal("  hello", "  hello  ".trimEnd());
        }

        [Fact]
        public void substring_ExtractsSubstring()
        {
            Assert.Equal("llo", "hello".substring(2));
            Assert.Equal("ll", "hello".substring(2, 4));
        }

        [Fact]
        public void slice_ExtractsSlice()
        {
            Assert.Equal("llo", "hello".slice(2));
            Assert.Equal("ll", "hello".slice(2, 4));
        }

        [Fact]
        public void slice_NegativeIndices_CountsFromEnd()
        {
            Assert.Equal("lo", "hello".slice(-2));
            Assert.Equal("ell", "hello".slice(1, -1));
        }

        [Fact]
        public void indexOf_FindsFirstOccurrence()
        {
            Assert.Equal(1, "hello".indexOf("e"));
            Assert.Equal(2, "hello".indexOf("ll"));
            Assert.Equal(-1, "hello".indexOf("x"));
        }

        [Fact]
        public void indexOf_WithPosition_StartsSearch()
        {
            Assert.Equal(4, "hello hello".indexOf("o", 3));
        }

        [Fact]
        public void lastIndexOf_FindsLastOccurrence()
        {
            Assert.Equal(10, "hello hello".lastIndexOf("o"));
            Assert.Equal(4, "hello".lastIndexOf("o"));
        }

        [Fact]
        public void startsWith_ChecksPrefix()
        {
            Assert.True("hello".startsWith("hel"));
            Assert.False("hello".startsWith("llo"));
        }

        [Fact]
        public void endsWith_ChecksSuffix()
        {
            Assert.True("hello".endsWith("llo"));
            Assert.False("hello".endsWith("hel"));
        }

        [Fact]
        public void includes_ChecksContains()
        {
            Assert.True("hello world".includes("world"));
            Assert.False("hello world".includes("goodbye"));
        }

        [Fact]
        public void replace_ReplacesOccurrences()
        {
            Assert.Equal("hi world", "hello world".replace("hello", "hi"));
            Assert.Equal("hxllo", "hello".replace("e", "x"));
        }

        [Fact]
        public void repeat_RepeatsString()
        {
            Assert.Equal("lalala", "la".repeat(3));
            Assert.Equal("", "x".repeat(0));
        }

        [Fact]
        public void padStart_PadsAtStart()
        {
            Assert.Equal("  hi", "hi".padStart(4));
            Assert.Equal("xxhi", "hi".padStart(4, "x"));
        }

        [Fact]
        public void padEnd_PadsAtEnd()
        {
            Assert.Equal("hi  ", "hi".padEnd(4));
            Assert.Equal("hixx", "hi".padEnd(4, "x"));
        }

        [Fact]
        public void charAt_GetsCharacter()
        {
            Assert.Equal("e", "hello".charAt(1));
            Assert.Equal("", "hello".charAt(10));
        }

        [Fact]
        public void charCodeAt_GetsCharCode()
        {
            Assert.Equal(101.0, "hello".charCodeAt(1)); // 'e'
            Assert.True(double.IsNaN("hello".charCodeAt(10)));
        }

        [Fact]
        public void split_SplitsString()
        {
            var result = "a,b,c".split(",");
            Assert.Equal(3, result.Count);
            Assert.Equal("a", result[0]);
            Assert.Equal("b", result[1]);
            Assert.Equal("c", result[2]);
        }

        [Fact]
        public void split_WithLimit_LimitsResults()
        {
            var result = "a,b,c,d".split(",", 2);
            Assert.Equal(2, result.Count);
            Assert.Equal("a", result[0]);
            Assert.Equal("b", result[1]);
        }

        [Fact]
        public void length_ReturnsStringLength()
        {
            Assert.Equal(5, "hello".length());
            Assert.Equal(0, "".length());
        }

        // New method tests

        [Fact]
        public void at_PositiveIndex_ReturnsCharacter()
        {
            Assert.Equal("e", "hello".at(1));
            Assert.Equal("o", "hello".at(4));
        }

        [Fact]
        public void at_NegativeIndex_CountsFromEnd()
        {
            Assert.Equal("o", "hello".at(-1));
            Assert.Equal("l", "hello".at(-2));
        }

        [Fact]
        public void codePointAt_ReturnsCodePoint()
        {
            Assert.Equal(104, "hello".codePointAt(0)); // 'h'
            Assert.Equal(101, "hello".codePointAt(1)); // 'e'
        }

        [Fact]
        public void concat_ConcatenatesStrings()
        {
            Assert.Equal("helloworld", "hello".concat("world"));
            Assert.Equal("abc", "a".concat("b", "c"));
        }

        [Fact]
        public void localeCompare_ComparesStrings()
        {
            Assert.True("a".localeCompare("b") < 0);
            Assert.True("b".localeCompare("a") > 0);
            Assert.Equal(0, "a".localeCompare("a"));
        }

        [Fact]
        public void match_FindsPattern()
        {
            var result = "hello world".match("wor");
            Assert.NotNull(result);
            Assert.Equal("wor", result[0]);
        }

        [Fact]
        public void match_NoMatch_ReturnsNull()
        {
            var result = "hello".match("xyz");
            Assert.Null(result);
        }

        [Fact]
        public void matchAll_FindsAllMatches()
        {
            var result = "test test test".matchAll("test");
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void search_FindsPatternIndex()
        {
            Assert.Equal(6, "hello world".search("world"));
            Assert.Equal(-1, "hello".search("xyz"));
        }

        [Fact]
        public void replaceAll_ReplacesAllOccurrences()
        {
            Assert.Equal("hi hi hi", "hello hello hello".replaceAll("hello", "hi"));
        }

        [Fact]
        public void normalize_NormalizesUnicode()
        {
            var str = "\u00e9"; // é
            var normalized = str.normalize("NFC");
            Assert.NotNull(normalized);
        }

        [Fact]
        public void substr_ExtractsSubstring()
        {
            Assert.Equal("llo", "hello".substr(2));
            Assert.Equal("ll", "hello".substr(2, 2));
        }

        [Fact]
        public void substr_NegativeStart_CountsFromEnd()
        {
            Assert.Equal("lo", "hello".substr(-2));
        }

        [Fact]
        public void toLocaleLowerCase_ConvertsToLowerCase()
        {
            Assert.Equal("hello", "HELLO".toLocaleLowerCase());
        }

        [Fact]
        public void toLocaleUpperCase_ConvertsToUpperCase()
        {
            Assert.Equal("HELLO", "hello".toLocaleUpperCase());
        }

        [Fact]
        public void toString_ReturnsString()
        {
            Assert.Equal("hello", "hello".toString());
        }

        [Fact]
        public void valueOf_ReturnsString()
        {
            Assert.Equal("hello", "hello".valueOf());
        }

        [Fact]
        public void isWellFormed_WellFormedString_ReturnsTrue()
        {
            Assert.True("hello".isWellFormed());
        }

        [Fact]
        public void isWellFormed_IllFormedString_ReturnsFalse()
        {
            // High surrogate without low surrogate
            var illFormed = "\ud800";
            Assert.False(illFormed.isWellFormed());
        }

        [Fact]
        public void toWellFormed_FixesIllFormedString()
        {
            var illFormed = "\ud800"; // High surrogate alone
            var wellFormed = illFormed.toWellFormed();
            Assert.NotEqual(illFormed, wellFormed);
            Assert.True(wellFormed.isWellFormed());
        }

        [Fact]
        public void trimLeft_RemovesLeadingWhitespace()
        {
            Assert.Equal("hello  ", "  hello  ".trimLeft());
        }

        [Fact]
        public void trimRight_RemovesTrailingWhitespace()
        {
            Assert.Equal("  hello", "  hello  ".trimRight());
        }

        [Fact]
        public void fromCharCode_CreatesStringFromCharCodes()
        {
            Assert.Equal("ABC", String.fromCharCode(65, 66, 67));
        }

        [Fact]
        public void fromCodePoint_CreatesStringFromCodePoints()
        {
            Assert.Equal("ABC", String.fromCodePoint(65, 66, 67));
        }

        [Fact]
        public void raw_CreatesRawTemplateString()
        {
            var template = new List<string> { "Hello ", " world", "!" };
            Assert.Equal("Hello X world!", String.raw(template, "X"));
        }
    }
}
