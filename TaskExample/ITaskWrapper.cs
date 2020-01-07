namespace TaskExample
{
	public interface ITaskWrapper
	{
		void ExecuteTasks();
		void ReadFiles(FileObject queue);
		void EnqueueTasks(string dirPath);
		void DequeueTasks();
	}
}
