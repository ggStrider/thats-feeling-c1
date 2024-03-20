using UnityEngine;
using System;
using System.Linq;
using TMPro;
using UnityEngine.Events;

namespace Player
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private TaskSettings[] _tasks;

        [ContextMenu("show")]
        public void _ShowTasks()
        {
            foreach (var task in _tasks)
            {
                task.TextComponent.text = task.TaskText;
            }
        }

        public void _CompleteTaskByIndex(int taskIndex)
        {
            if(_tasks[taskIndex].Completed) return;
            
            _tasks[taskIndex].Completed = true;
            _tasks[taskIndex].OnTaskCompleted?.Invoke();
        }

        public void _CompleteTaskByShortDescription(string shortDescription)
        {
            var checkedTask = CheckByDescription(shortDescription);
            if(checkedTask == null || checkedTask.Completed) return;

            checkedTask.Completed = true;
            checkedTask.OnTaskCompleted?.Invoke();
        }

        private TaskSettings CheckByDescription(string description)
        {
            return _tasks.FirstOrDefault(task => task.ShortDescription.ToLower() == description.ToLower());
        }

        [Serializable]
        public class TaskSettings
        {
            public string TaskText;
            public TextMeshProUGUI TextComponent;
            
            [Space]
            public UnityEvent OnTaskCompleted;
            
            [field:SerializeField] public string ShortDescription { get; private set; }
            
            public bool Completed;
        }
    }
}