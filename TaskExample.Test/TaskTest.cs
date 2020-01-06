using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace TaskExample.UnitTest
{
    [TestClass]
    public class TaskTest
    {
		[TestMethod]
		public void Enqueue_TaskAdd_ToQueue()
		{
			// Arrange		
			var fileQueue = new FileQueue();

			void Action1()
			{
			}

			fileQueue.Enqueue(Action1);

			void Action2()
			{
			}

			fileQueue.Enqueue(Action2);

			void Action3()
			{
			}

			fileQueue.Enqueue(Action3);


			// Assert
			fileQueue._queue.Count.ShouldBe(3);
		}
	}
}
