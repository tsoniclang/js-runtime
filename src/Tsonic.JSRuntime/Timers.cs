/**
 * JavaScript Timer functions implementation
 * Provides setTimeout, clearTimeout, setInterval, clearInterval
 */

using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Tsonic.JSRuntime
{
    /// <summary>
    /// JavaScript-style timer functions for NativeAOT
    /// </summary>
    public static class Timers
    {
        private static int _nextId = 1;
        private static readonly ConcurrentDictionary<int, Timer> _timers = new();
        private static readonly ConcurrentDictionary<int, CancellationTokenSource> _timeouts = new();

        /// <summary>
        /// Schedule a callback to run after a delay (one-shot timer)
        /// </summary>
        public static int setTimeout(Action callback, int delayMs = 0)
        {
            var id = Interlocked.Increment(ref _nextId);
            var cts = new CancellationTokenSource();
            _timeouts[id] = cts;

            var timer = new Timer(_ =>
            {
                if (!cts.Token.IsCancellationRequested)
                {
                    callback();
                }
                // Clean up after execution
                _timeouts.TryRemove(id, out CancellationTokenSource? _);
                if (_timers.TryRemove(id, out Timer? t))
                {
                    t.Dispose();
                }
            }, null, delayMs, Timeout.Infinite);

            _timers[id] = timer;
            return id;
        }

        /// <summary>
        /// Schedule a callback to run after a delay with arguments
        /// </summary>
        public static int setTimeout<T>(Action<T> callback, int delayMs, T arg)
        {
            return setTimeout(() => callback(arg), delayMs);
        }

        /// <summary>
        /// Cancel a timeout
        /// </summary>
        public static void clearTimeout(int id)
        {
            if (_timeouts.TryRemove(id, out var cts))
            {
                cts.Cancel();
                cts.Dispose();
            }
            if (_timers.TryRemove(id, out var timer))
            {
                timer.Dispose();
            }
        }

        /// <summary>
        /// Schedule a callback to run repeatedly at an interval
        /// </summary>
        public static int setInterval(Action callback, int intervalMs)
        {
            var id = Interlocked.Increment(ref _nextId);
            var cts = new CancellationTokenSource();
            _timeouts[id] = cts;

            var timer = new Timer(_ =>
            {
                if (!cts.Token.IsCancellationRequested)
                {
                    callback();
                }
            }, null, intervalMs, intervalMs);

            _timers[id] = timer;
            return id;
        }

        /// <summary>
        /// Schedule a callback to run repeatedly with arguments
        /// </summary>
        public static int setInterval<T>(Action<T> callback, int intervalMs, T arg)
        {
            return setInterval(() => callback(arg), intervalMs);
        }

        /// <summary>
        /// Cancel an interval
        /// </summary>
        public static void clearInterval(int id)
        {
            // Same implementation as clearTimeout
            clearTimeout(id);
        }
    }
}
