namespace TaskExample.UnitTest
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Shouldly;

	[TestClass]
    public class FileQueueTest
    {
		[TestMethod]
		public void Enqueue_TaskAdd_ToQueue()
		{
			// Arrange		
			var fileQueue = this.CreateFixture();

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
			//Act
			fileQueue.Enqueue(Action3);

			// Assert
			fileQueue.CurrentQueue.Count.ShouldBe(3);
		}

		[TestMethod]
		public void DequeueTask()
		{
			// Arrange
			var fileQueue = this.CreateFixture();

			void Action1()
			{
			}

			fileQueue.Enqueue(Action1);

			// Act 
			fileQueue.Dequeue();

			// Assert
			fileQueue.CurrentQueue.Count.ShouldBe(0);
		}

		[TestMethod]
		public void Check_FileQueue_IsNotNull()
		{
			// Arrange and Act		
			var fileQueue = this.CreateFixture();

			//Assert
			fileQueue.CurrentQueue.ShouldNotBeNull();
		}

		private FileQueue CreateFixture()
		{
			var fileQueue = new FileQueue();
			return fileQueue;
		}
	}
}
