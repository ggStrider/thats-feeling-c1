using UnityEngine;
using UnityEngine.Events;
using TMPro;

using Sounds;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Player
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private bool _initializeTasksOnStart;
        [SerializeField] private TaskSettings[] _tasks;

        [SerializeField] private PlayRandomSound _playSoundOnCompleted;
        [SerializeField] private bool _canCompleteTask = true;

        [SerializeField] private bool _initialized;
        
        [Space] [SerializeField] private float _alphaDeltaSpeed = 0.01f;

        [SerializeField] private UnityEvent _onAllTasksComplete;

        private void Start()
        {
            if (!_initializeTasksOnStart) return;
            _ShowTasks();
        }

        [ContextMenu("show")]
        public void _ShowTasks()
        {
            if (_initialized) return;
            _initialized = true;

            foreach (var task in _tasks)
            {
                task.TextComponent.text = task.TaskText;
                task.TextComponent.gameObject.SetActive(true);
                if (task.UseAppearAnimation)
                {
                    AddAlphaToText(task.TextComponent);
                }
            }
        }

        private async void AddAlphaToText(TextMeshProUGUI textToRemoveAlpha)
        {
            var newColor = textToRemoveAlpha.color;
            
            while (textToRemoveAlpha.color.a < 0.9f)
            {
                newColor.a = Mathf.Clamp01(newColor.a + _alphaDeltaSpeed);
                textToRemoveAlpha.color = newColor;

                await Task.Yield();
            }
        }
        
        private async void DecreaseAlphaToText(TextMeshProUGUI textToRemoveAlpha)
        {
            var newColor = textToRemoveAlpha.color;
            
            while (textToRemoveAlpha.color.a > 0)
            {
                newColor.a = Mathf.Clamp01(newColor.a - _alphaDeltaSpeed);
                textToRemoveAlpha.color = newColor;

                await Task.Yield();
            }
        }

        public void _CompleteTaskByIndex(int taskIndex)
        {
            if (_tasks[taskIndex].Completed || !_canCompleteTask) return;

            _tasks[taskIndex].Completed = true;
            _tasks[taskIndex].TextComponent.fontStyle = FontStyles.Strikethrough;
            _tasks[taskIndex].OnTaskCompleted?.Invoke();
            
            if (CheckIsAllTasksComplete())
            {
                _onAllTasksComplete?.Invoke();
            }

            if (_playSoundOnCompleted == null) return;
            _playSoundOnCompleted._PlayRandomSound();
        }

        public void _CompleteTaskByShortDescription(string shortDescription)
        {
            var checkedTask = CheckIsThereTaskWithParamDescription(shortDescription.ToLower());
            if (checkedTask == null || checkedTask.Completed || !_canCompleteTask) return;

            checkedTask.Completed = true;
            checkedTask.TextComponent.fontStyle = FontStyles.Strikethrough;
            checkedTask.OnTaskCompleted?.Invoke();

            if (CheckIsAllTasksComplete())
            {
                _onAllTasksComplete?.Invoke();
            }

            if (_playSoundOnCompleted == null) return;
            _playSoundOnCompleted._PlayRandomSound();
        }

        private bool CheckIsAllTasksComplete()
        {
            return _tasks.All(checkTask => checkTask.Completed);
        }

        private TaskSettings CheckIsThereTaskWithParamDescription(string description)
        {
            return _tasks.FirstOrDefault(task => task.ShortDescription.ToLower() == description);
        }

        public void _SetCanComplete(bool canComplete)
        {
            _canCompleteTask = canComplete;
        }
        
        public void _HideTasks()
        {
            foreach (var task in _tasks)
            {
                DecreaseAlphaToText(task.TextComponent);
            }
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

            [Space] public bool UseAppearAnimation = true;
        }
    }
}