using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmQuests
{
    interface ILessons
    {
        public string NameTask { get; set; }
        public string Description { get; set; }
        void StartTask();
        void ShowTask();
        void TaskLogic();
    }
}
