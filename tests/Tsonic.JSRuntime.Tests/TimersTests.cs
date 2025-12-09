using System;
using System.Threading;
using Xunit;

namespace Tsonic.JSRuntime.Tests
{
    public class TimersTests
    {
        // ==================== setTimeout Tests ====================

        [Fact]
        public void setTimeout_ExecutesCallbackAfterDelay()
        {
            var executed = false;
            var id = Timers.setTimeout(() => executed = true, 50);

            Assert.False(executed);
            Thread.Sleep(100);
            Assert.True(executed);
        }

        [Fact]
        public void setTimeout_ReturnsUniqueId()
        {
            var id1 = Timers.setTimeout(() => { }, 1000);
            var id2 = Timers.setTimeout(() => { }, 1000);

            Assert.NotEqual(id1, id2);

            // Clean up
            Timers.clearTimeout(id1);
            Timers.clearTimeout(id2);
        }

        [Fact]
        public void setTimeout_WithZeroDelay_ExecutesCallback()
        {
            var executed = false;
            Timers.setTimeout(() => executed = true, 0);

            Thread.Sleep(50);
            Assert.True(executed);
        }

        [Fact]
        public void setTimeout_DefaultDelay_IsZero()
        {
            var executed = false;
            Timers.setTimeout(() => executed = true);

            Thread.Sleep(50);
            Assert.True(executed);
        }

        [Fact]
        public void setTimeout_ExecutesOnlyOnce()
        {
            var count = 0;
            Timers.setTimeout(() => count++, 50);

            Thread.Sleep(200);
            Assert.Equal(1, count);
        }

        [Fact]
        public void setTimeout_WithArgument_PassesArgument()
        {
            string? received = null;
            Timers.setTimeout<string>(arg => received = arg, 50, "hello");

            Thread.Sleep(100);
            Assert.Equal("hello", received);
        }

        // ==================== clearTimeout Tests ====================

        [Fact]
        public void clearTimeout_PreventsExecution()
        {
            var executed = false;
            var id = Timers.setTimeout(() => executed = true, 100);

            Timers.clearTimeout(id);
            Thread.Sleep(200);
            Assert.False(executed);
        }

        [Fact]
        public void clearTimeout_WithInvalidId_DoesNotThrow()
        {
            // Should not throw for non-existent ID
            var exception = Record.Exception(() => Timers.clearTimeout(99999));
            Assert.Null(exception);
        }

        [Fact]
        public void clearTimeout_CalledTwice_DoesNotThrow()
        {
            var id = Timers.setTimeout(() => { }, 1000);

            Timers.clearTimeout(id);
            var exception = Record.Exception(() => Timers.clearTimeout(id));
            Assert.Null(exception);
        }

        [Fact]
        public void clearTimeout_AfterExecution_DoesNotThrow()
        {
            var id = Timers.setTimeout(() => { }, 10);

            Thread.Sleep(50);
            var exception = Record.Exception(() => Timers.clearTimeout(id));
            Assert.Null(exception);
        }

        // ==================== setInterval Tests ====================

        [Fact]
        public void setInterval_ExecutesRepeatedly()
        {
            var count = 0;
            var id = Timers.setInterval(() => count++, 50);

            Thread.Sleep(180);
            Timers.clearInterval(id);

            Assert.True(count >= 2, $"Expected at least 2 executions, got {count}");
        }

        [Fact]
        public void setInterval_ReturnsUniqueId()
        {
            var id1 = Timers.setInterval(() => { }, 1000);
            var id2 = Timers.setInterval(() => { }, 1000);

            Assert.NotEqual(id1, id2);

            // Clean up
            Timers.clearInterval(id1);
            Timers.clearInterval(id2);
        }

        [Fact]
        public void setInterval_WithArgument_PassesArgument()
        {
            var received = new System.Collections.Generic.List<string>();
            var id = Timers.setInterval<string>(arg => received.Add(arg), 50, "test");

            Thread.Sleep(180);
            Timers.clearInterval(id);

            Assert.True(received.Count >= 2);
            Assert.All(received, item => Assert.Equal("test", item));
        }

        // ==================== clearInterval Tests ====================

        [Fact]
        public void clearInterval_StopsExecution()
        {
            var count = 0;
            var id = Timers.setInterval(() => count++, 50);

            Thread.Sleep(100);
            Timers.clearInterval(id);
            var countAfterClear = count;

            Thread.Sleep(150);
            Assert.Equal(countAfterClear, count);
        }

        [Fact]
        public void clearInterval_WithInvalidId_DoesNotThrow()
        {
            var exception = Record.Exception(() => Timers.clearInterval(99999));
            Assert.Null(exception);
        }

        [Fact]
        public void clearInterval_CalledTwice_DoesNotThrow()
        {
            var id = Timers.setInterval(() => { }, 1000);

            Timers.clearInterval(id);
            var exception = Record.Exception(() => Timers.clearInterval(id));
            Assert.Null(exception);
        }

        // ==================== Mixed Usage Tests ====================

        [Fact]
        public void setTimeout_And_setInterval_UseUniqueIds()
        {
            var timeoutId = Timers.setTimeout(() => { }, 1000);
            var intervalId = Timers.setInterval(() => { }, 1000);

            Assert.NotEqual(timeoutId, intervalId);

            Timers.clearTimeout(timeoutId);
            Timers.clearInterval(intervalId);
        }

        [Fact]
        public void clearTimeout_CanClearInterval()
        {
            // In JavaScript, clearTimeout and clearInterval are interchangeable
            var count = 0;
            var id = Timers.setInterval(() => count++, 50);

            Thread.Sleep(100);
            Timers.clearTimeout(id); // Using clearTimeout on interval
            var countAfterClear = count;

            Thread.Sleep(150);
            Assert.Equal(countAfterClear, count);
        }

        [Fact]
        public void clearInterval_CanClearTimeout()
        {
            // In JavaScript, clearTimeout and clearInterval are interchangeable
            var executed = false;
            var id = Timers.setTimeout(() => executed = true, 100);

            Timers.clearInterval(id); // Using clearInterval on timeout
            Thread.Sleep(200);
            Assert.False(executed);
        }

        // ==================== Concurrency Tests ====================

        [Fact]
        public void setTimeout_MultipleTimers_AllExecute()
        {
            var results = new bool[3];

            Timers.setTimeout(() => results[0] = true, 30);
            Timers.setTimeout(() => results[1] = true, 60);
            Timers.setTimeout(() => results[2] = true, 90);

            Thread.Sleep(150);
            Assert.All(results, r => Assert.True(r));
        }

        [Fact]
        public void setInterval_MultipleIntervals_AllExecute()
        {
            var counts = new int[2];

            var id1 = Timers.setInterval(() => counts[0]++, 50);
            var id2 = Timers.setInterval(() => counts[1]++, 50);

            Thread.Sleep(180);

            Timers.clearInterval(id1);
            Timers.clearInterval(id2);

            Assert.True(counts[0] >= 2);
            Assert.True(counts[1] >= 2);
        }

        // ==================== Edge Cases ====================

        [Fact]
        public void setTimeout_VeryShortDelay_ExecutesQuickly()
        {
            var executed = false;
            Timers.setTimeout(() => executed = true, 1);

            Thread.Sleep(50);
            Assert.True(executed);
        }

        [Fact]
        public void setInterval_VeryShortInterval_ExecutesMultipleTimes()
        {
            var count = 0;
            var id = Timers.setInterval(() => count++, 10);

            Thread.Sleep(100);
            Timers.clearInterval(id);

            Assert.True(count >= 5, $"Expected at least 5 executions, got {count}");
        }
    }
}
