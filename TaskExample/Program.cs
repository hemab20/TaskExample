using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter directory path to read files");
            var dirPath = @"" + Console.ReadLine();
            var t1 = Task.Factory.StartNew(() => EnqueueTasks(dirPath));
            var t2 = Task.Factory.StartNew(() => DequeueTasks());
            Task.WaitAll(t1, t2);
            Console.ReadLine();
        }

        public static void ReadFiles(ThreadObject queue)
        {
            File.ReadAllText(queue.FilePath);

            Console.WriteLine
            (
            "Dequeued: " + queue.FileID +
            "\t" + "File Name: " + queue.FileName +
            "\t" + "Read file from path: " + queue.FilePath +
            "\t" + "Dequeue ThreadID :" + Thread.CurrentThread.ManagedThreadId
            );
        }

        public static void EnqueueTasks(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                string[] files = Directory.GetFiles(dirPath);

                for (int i = 0; i < files.Length; i++)
                {
                    var queue = new ThreadObject
                    {
                        FileID = i,
                        FileName = Path.GetFileName(files[i]),
                        FilePath = Path.GetFullPath(files[i]),
                        EnqueueThreadID = Thread.CurrentThread.ManagedThreadId,
                    };

                    FileQueue.Enqueue(() => { ReadFiles(queue); });

                    Console.WriteLine
                        (
                        "Enqueued: " + queue.FileID +
                        "\t" + "File Name: " + queue.FileName +
                        "\t" + "Enqueue ThreadID: " + queue.EnqueueThreadID
                        );
                }
            }
        }

        public static void DequeueTasks()
        {
            FileQueue.Dequeue();
        }
    }
}
