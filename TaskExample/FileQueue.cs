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
        public ConcurrentQueue<Task> _queue;

        public FileQueue()
        {
            _queue = new ConcurrentQueue<Task>();
        }

        // Enqueue Task in queue
        public void Enqueue(Action action)
        {
			try
			{
				Task task = new Task(action);
				_queue.Enqueue(task);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

        // Dequeue task from queue
        public void Dequeue()
        {
            while (true)
            {
                try
                {
                    Task task;
                    if (_queue.TryDequeue(out task))
                    {
						if (task != null)
						{
							//Run the dequeued task on separate thread
							var t = Task.Factory.StartNew(() => task.Start());
							t.Wait();
						}
						else
						{
							return;
						}
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
