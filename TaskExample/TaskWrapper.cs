﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskExample
{
	public class TaskWrapper : ITaskWrapper
	{
		FileQueue fileQueue = new FileQueue();
		public void ExecuteTasks()
		{
			Console.WriteLine("Enter directory path to read files");
			var dirPath = @"" + Console.ReadLine();

			var t1 = Task.Factory.StartNew(() => EnqueueTasks(dirPath));

			var t2 = Task.Factory.StartNew(() => DequeueTasks());
			Task.WaitAll(t1, t2);
		}

		public static void ReadFiles(FileObject queue)
		{
			//var fileStream =  File.ReadAllText(queue.FilePath);
			//Simulate the file read operation
			Console.WriteLine("Dequeued File Read Task Completed. File Name " + queue.FileName);
		}

		public void EnqueueTasks(string dirPath)
		{
			if (Directory.Exists(dirPath))
			{
				string[] files = Directory.GetFiles(dirPath);

				for (int i = 0; i < files.Length; i++)
				{
					var queue = new FileObject
					{
						FileID = i,
						FileName = Path.GetFileName(files[i]),
						FilePath = Path.GetFullPath(files[i]),
					};

					fileQueue.Enqueue(() => { ReadFiles(queue); });

					Console.WriteLine
						(
						"Enqueued: " + queue.FileID +
						"\t" + "File Name: " + queue.FileName 
						);
				}
			}
		}

		public void DequeueTasks()
		{
			fileQueue.Dequeue();
		}
	}
}
