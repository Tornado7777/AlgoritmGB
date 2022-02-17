

namespace TaskLibrary
{
    public interface ILessons
    {
        public string NameTask { get; set; }
        public string Description { get; set; }
        void StartTask();
        void ShowTask();
        void TaskLogic();
    }
}
