using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace HW0206_ThreadSync
{
    class ThreadExecutor
    {
        Queue<Thread> threads = new Queue<Thread>();
        //if we use cincurrent queue , delete the lock statements in the methods:
        //ConcurrentQueue<Thread> threads2 = new ConcurrentQueue<Thread>();

        public ThreadExecutor()
        {
            ThreadPool.QueueUserWorkItem((a) =>
            {
                Console.WriteLine("Hello from the thread pool.");

                if (threads.Count != 0)
                {
                    Execute();
                }
            });
            //System.Timers.Timer timer = new System.Timers.Timer(1000);
            //timer.Elapsed += OnTimeElapsed;
            //timer.Enabled = true;
        }

        private void OnTimeElapsed(object sender, ElapsedEventArgs e)
        {            
            new Thread(new ThreadStart(() =>
            {
                if (threads.Count != 0)
                {
                    Execute();
                }
            })).Start();
        }

        public void Add(Thread thread)
        {
            lock (this)
            {
                threads.Enqueue(thread);
            }
        }
        public void Execute()
        {
            while (threads.Count !=0)
            {
                Thread t = threads.Peek();
                t.Start();
                t.Join();
                threads.Dequeue();
            }
        }
    }
}
