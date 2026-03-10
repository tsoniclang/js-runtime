using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Tsonic.JSRuntime.Tests
{
    public class TimersTests
    {
        private static void WaitFor(ManualResetEventSlim signal, int timeoutMs, string message)
        {
            Assert.True(signal.Wait(timeoutMs), message);
        }

        private static void WaitUntil(Func<bool> predicate, int timeoutMs, string message)
        {
            var deadline = Stopwatch.GetTimestamp() + (long)(timeoutMs * (Stopwatch.Frequency / 1000.0));
            while (Stopwatch.GetTimestamp() < deadline)
            {
                if (predicate())
                {
                    return;
                }

                Thread.Sleep(5);
            }

            Assert.True(predicate(), message);
        }

        private static void AssertStays(Func<bool> predicate, int durationMs, string message)
        {
            var deadline = Stopwatch.GetTimestamp() + (long)(durationMs * (Stopwatch.Frequency / 1000.0));
            while (Stopwatch.GetTimestamp() < deadline)
            {
                Assert.True(predicate(), message);
                Thread.Sleep(5);
            }
        }

        // ==================== setTimeout Tests ====================

        [Fact]
        public void setTimeout_ExecutesCallbackAfterDelay()
        {
            using var executed = new ManualResetEventSlim(false);
            var id = Timers.setTimeout(() => executed.Set(), 50);

            Assert.False(executed.IsSet);
            WaitFor(executed, 1000, "setTimeout callback did not execute within the expected timeout window.");
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
            using var executed = new ManualResetEventSlim(false);
            Timers.setTimeout(() => executed.Set(), 0);

            WaitFor(executed, 1000, "Zero-delay setTimeout did not execute.");
        }

        [Fact]
        public void setTimeout_TruncatesFractionalDelay()
        {
            using var executed = new ManualResetEventSlim(false);
            Timers.setTimeout(() => executed.Set(), 10.9);

            WaitFor(executed, 1000, "Fractional-delay setTimeout did not execute.");
        }

        [Fact]
        public void setTimeout_DefaultDelay_IsZero()
        {
            using var executed = new ManualResetEventSlim(false);
            Timers.setTimeout(() => executed.Set());

            WaitFor(executed, 1000, "Default-delay setTimeout did not execute.");
        }

        [Fact]
        public void setTimeout_ExecutesOnlyOnce()
        {
            var count = 0;
            Timers.setTimeout(() => count++, 50);

            WaitUntil(() => Volatile.Read(ref count) == 1, 1000, "setTimeout did not execute exactly once.");
            AssertStays(() => Volatile.Read(ref count) == 1, 250, "setTimeout executed more than once.");
            Assert.Equal(1, count);
        }

        [Fact]
        public void setTimeout_WithArgument_PassesArgument()
        {
            string? received = null;
            using var delivered = new ManualResetEventSlim(false);
            Timers.setTimeout<string>(arg =>
            {
                received = arg;
                delivered.Set();
            }, 50, "hello");

            WaitFor(delivered, 1000, "setTimeout with argument did not execute.");
            Assert.Equal("hello", received);
        }

        // ==================== clearTimeout Tests ====================

        [Fact]
        public void clearTimeout_PreventsExecution()
        {
            using var executed = new ManualResetEventSlim(false);
            var id = Timers.setTimeout(() => executed.Set(), 100);

            Timers.clearTimeout(id);
            Assert.False(executed.Wait(300), "clearTimeout did not prevent callback execution.");
        }

        [Fact]
        public void clearTimeout_WithInvalidId_DoesNotThrow()
        {
            // Should not throw for non-existent ID
            var exception = Record.Exception(() => Timers.clearTimeout(99999));
            Assert.Null(exception);
        }

        [Fact]
        public void clearTimeout_WithNonIntegralId_DoesNotThrow()
        {
            var exception = Record.Exception(() => Timers.clearTimeout(99999.5));
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
            using var executed = new ManualResetEventSlim(false);
            var id = Timers.setTimeout(() => executed.Set(), 10);

            WaitFor(executed, 1000, "Timeout did not execute before clearTimeout-after-execution check.");
            var exception = Record.Exception(() => Timers.clearTimeout(id));
            Assert.Null(exception);
        }

        // ==================== setInterval Tests ====================

        [Fact]
        public void setInterval_ExecutesRepeatedly()
        {
            var count = 0;
            var id = Timers.setInterval(() => count++, 50);

            WaitUntil(() => Volatile.Read(ref count) >= 2, 1000, $"Expected at least 2 executions, got {Volatile.Read(ref count)}.");
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
            var received = new List<string>();
            var id = Timers.setInterval<string>(arg => received.Add(arg), 50, "test");

            WaitUntil(() => received.Count >= 2, 1000, $"Expected at least 2 interval executions, got {received.Count}.");
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

            WaitUntil(() => Volatile.Read(ref count) >= 1, 1000, "Interval did not tick before clearInterval.");
            Timers.clearInterval(id);
            var countAfterClear = count;

            AssertStays(() => Volatile.Read(ref count) == countAfterClear, 250, "clearInterval did not stop further executions.");
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

        [Fact]
        public void clearInterval_DoesNotRaceWithActiveCallbacks()
        {
            for (var iteration = 0; iteration < 200; iteration++)
            {
                var sawTick = new ManualResetEventSlim(false);
                var id = Timers.setInterval(() => sawTick.Set(), 1);

                Assert.True(sawTick.Wait(1000));
                Timers.clearInterval(id);
                Thread.Sleep(5);
            }
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
            var count = 0;
            var id = Timers.setInterval(() => count++, 50);

            WaitUntil(() => Volatile.Read(ref count) >= 1, 1000, "Interval did not tick before cross-clear.");
            Timers.clearTimeout(id);
            var countAfterClear = count;

            AssertStays(() => Volatile.Read(ref count) == countAfterClear, 250, "clearTimeout did not stop interval executions.");
            Assert.Equal(countAfterClear, count);
        }

        [Fact]
        public void clearInterval_CanClearTimeout()
        {
            using var executed = new ManualResetEventSlim(false);
            var id = Timers.setTimeout(() => executed.Set(), 100);

            Timers.clearInterval(id);
            Assert.False(executed.Wait(300), "clearInterval did not prevent timeout execution.");
        }

        // ==================== Concurrency Tests ====================

        [Fact]
        public void setTimeout_MultipleTimers_AllExecute()
        {
            var results = new bool[3];
            using var allExecuted = new CountdownEvent(3);

            Timers.setTimeout(() =>
            {
                results[0] = true;
                allExecuted.Signal();
            }, 30);
            Timers.setTimeout(() =>
            {
                results[1] = true;
                allExecuted.Signal();
            }, 60);
            Timers.setTimeout(() =>
            {
                results[2] = true;
                allExecuted.Signal();
            }, 90);

            Assert.True(allExecuted.Wait(1000), "Not all timeout callbacks executed within the expected window.");
            Assert.All(results, r => Assert.True(r));
        }

        [Fact]
        public void setInterval_MultipleIntervals_AllExecute()
        {
            var counts = new int[2];

            var id1 = Timers.setInterval(() => counts[0]++, 50);
            var id2 = Timers.setInterval(() => counts[1]++, 50);

            WaitUntil(
                () => Volatile.Read(ref counts[0]) >= 2 && Volatile.Read(ref counts[1]) >= 2,
                1000,
                $"Expected both intervals to execute at least twice, got {counts[0]} and {counts[1]}."
            );

            Timers.clearInterval(id1);
            Timers.clearInterval(id2);

            Assert.True(counts[0] >= 2);
            Assert.True(counts[1] >= 2);
        }

        // ==================== Edge Cases ====================

        [Fact]
        public void setTimeout_VeryShortDelay_ExecutesQuickly()
        {
            using var executed = new ManualResetEventSlim(false);
            Timers.setTimeout(() => executed.Set(), 1);

            WaitFor(executed, 1000, "Very-short-delay setTimeout did not execute.");
        }

        [Fact]
        public void setInterval_VeryShortInterval_ExecutesMultipleTimes()
        {
            var count = 0;
            var id = Timers.setInterval(() => count++, 10);

            WaitUntil(() => Volatile.Read(ref count) >= 5, 1000, $"Expected at least 5 executions, got {Volatile.Read(ref count)}.");
            Timers.clearInterval(id);

            Assert.True(count >= 5, $"Expected at least 5 executions, got {count}");
        }
    }
}
