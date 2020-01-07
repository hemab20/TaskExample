# TaskExample
This Example is for creating the task(s) on multiple threads to read the files from directory in sequential manner
1. Adding of tasks with the EnqueueTask 
2. Processing of tasks with DequeueTask
	It contains ConcurrentQueue(thread-safe queue) for adding Tasks.
  
  FileQueue class performs all the actions on queue 
  TaskWrapper class will execute the task(adding files to queue and reading that files) using the FileQueue class methods.


Technologies used
1. ConcurrentQueue collection
2. TPL
3. Shouldly
