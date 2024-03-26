using UnityEngine;
using UnityEngine.Events;
using TMPro;

using Sounds;

using System;
using System.Linq;

namespace Player
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private bool _initializeTaskOnStart;
        [SerializeField] private TaskSettings[] _tasks;

        [SerializeField] private PlayRandomSound _playSound;
        [SerializeField] private bool _canCompleteTask = true;

        private void Start()
        {
            if (!_initializeTaskOnStart) return;
            _ShowTasks();
        }

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
            if(_tasks[taskIndex].Completed || !_canCompleteTask) return;
            
            _tasks[taskIndex].Completed = true;
            _tasks[taskIndex].TextComponent.fontStyle = FontStyles.Strikethrough;
            _tasks[taskIndex].OnTaskCompleted?.Invoke();
            
            _playSound._PlayRandomSound();
        }

        public void _CompleteTaskByShortDescription(string shortDescription)
        {
            var checkedTask = CheckByDescription(shortDescription);
            if(checkedTask == null || checkedTask.Completed || !_canCompleteTask) return;

            checkedTask.Completed = true;
            checkedTask.TextComponent.fontStyle = FontStyles.Strikethrough;
            checkedTask.OnTaskCompleted?.Invoke();
            
            _playSound._PlayRandomSound();
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