using System;
using System.Threading;

namespace Tsonic.JSRuntime
{
    /// <summary>
    /// Holds a foreground thread while ref-counted runtime handles are active.
    /// This gives Node/JS-style timers and servers the ability to keep the
    /// process alive until the last referenced handle is released.
    /// </summary>
    public static class ProcessKeepAlive
    {
        private static readonly object Sync = new();
        private static int _refCount;
        private static ManualResetEventSlim? _releaseSignal;
        private static Thread? _keeperThread;

        public static void Acquire()
        {
            lock (Sync)
            {
                _refCount++;
                if (_refCount != 1)
                {
                    return;
                }

                var releaseSignal = new ManualResetEventSlim(false);
                var keeperThread = new Thread(() => releaseSignal.Wait())
                {
                    IsBackground = false,
                    Name = "Tsonic.ProcessKeepAlive",
                };

                _releaseSignal = releaseSignal;
                _keeperThread = keeperThread;
                keeperThread.Start();
            }
        }

        public static void Release()
        {
            ManualResetEventSlim? releaseSignal = null;

            lock (Sync)
            {
                if (_refCount == 0)
                {
                    return;
                }

                _refCount--;
                if (_refCount != 0)
                {
                    return;
                }

                releaseSignal = _releaseSignal;
                _releaseSignal = null;
                _keeperThread = null;
            }

            releaseSignal?.Set();
        }
    }
}
