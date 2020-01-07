namespace TaskExample.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using TaskExample;
	using System.Threading.Tasks;
	using Shouldly;
	using System.Diagnostics;

	[TestClass]
	public class TaskWrapperTests
	{		
		[TestMethod]
		public void Ctor_AlwaysReturns_ValidInstance()
		{
			// Act
			var taskWrapper = this.CreateFixture();

			//Assert
			taskWrapper.ShouldNotBeNull();
		}

		[TestMethod]
		public void ExecuteTasks_AlwaysStart_ExecutingTask()
		{
			// Arrange 
			var taskwrapper = this.CreateFixture();
			Trace.WriteLine("Enter directory path");
			var path = @"C:\Users";

			// Act
			var t1 = Task.Factory.StartNew(() => taskwrapper.EnqueueTasks(path));

			var t2 = Task.Factory.StartNew(() => taskwrapper.DequeueTasks());
			Task.WaitAll(t1, t2);

			// Assert
			t1.ShouldNotBeNull();
			t2.ShouldNotBeNull();
		}

		[TestMethod]
		public void EnqueueTasks_Always_AddedtoQueue()
		{
			// Arrange 
			var taskwrapper = this.CreateFixture();
			var path = @"C:\Users";

			// Act
			taskwrapper.EnqueueTasks(path);
		}

		private TaskWrapper CreateFixture()
		{
			var taskWrapper = new TaskWrapper();
			return taskWrapper;
		}
	}
}