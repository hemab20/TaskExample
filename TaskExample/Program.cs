namespace TaskExample
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;

	class Program
    {
        public static void Main(string[] args)
        {
			var taskwrapper = new TaskWrapper();
			taskwrapper.ExecuteTasks();
			Console.ReadLine();
		}

       
    }
}
