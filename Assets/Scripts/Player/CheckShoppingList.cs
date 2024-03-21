using UnityEngine;
using Sounds;

using System.Threading.Tasks;

namespace Player
{
    public class CheckShoppingList : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        [Space, Header("In milliseconds")]
        [SerializeField] private int _delayBetweenChecking = 1500;

        [Space] [SerializeField] private bool _playSoundOnShowing;
        [SerializeField] private PlayRandomSound _playSoundComponent;
        public bool canCheck;

        private bool _showing;
        private static readonly int ShowKey = Animator.StringToHash("show");

        public void ToggleAnimation()
        {
            if (!canCheck) return;
            _showing = !_showing;
            canCheck = false;

            _animator.SetBool(ShowKey, _showing);
            if (_playSoundOnShowing && _showing)
            {
                _playSoundComponent._PlayRandomSound();
            }
            Delay();
        }

        private async void Delay()
        {
            await Task.Delay(_delayBetweenChecking);
            canCheck = true;
        }
    }
}