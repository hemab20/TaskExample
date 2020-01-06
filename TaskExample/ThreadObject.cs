using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskExample
{
    public class ThreadObject
    {
        public int FileID { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public int EnqueueThreadID { get; set; }
        public int DequeueThreadID { get; set; }
    }
}
