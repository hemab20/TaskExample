namespace TaskExample
{
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;

	public class FileQueue
    {
        // thread-safe queue to enqueue task
        private ConcurrentQueue<Task> _queue;

        public FileQueue()
        {
            this._queue = new ConcurrentQueue<Task>();
        }

		public ConcurrentQueue<Task> CurrentQueue
		{
			get { return this._queue; }
		}

        // Enqueue Task in queue
        public void Enqueue(Action action)
        {
			try
			{
				var task = new Task(action);
				this._queue.Enqueue(task);
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
							Thread.Sleep(200);
							t.Wait();
						}
						else
						{
							break;
						}
					}
					else
					{
						break;
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
