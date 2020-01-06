using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    public class FileQueue
    {
        // thread-safe queue to enqueue task
        static ConcurrentQueue<Task> _queue;

        static FileQueue()
        {
            _queue = new ConcurrentQueue<Task>();
        }

        // Enqueue Task in queue
        public static void Enqueue(Action action, CancellationToken cancelToken = default(CancellationToken))
        {
            Task task = new Task(action, cancelToken);
            _queue.Enqueue(task);
        }

        // Dequeue task from queue
        public static void Dequeue()
        {
            while (true)
            {
                try
                {
                    Task task;
                    if (_queue.TryDequeue(out task))
                    {
                        task.RunSynchronously();

                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
