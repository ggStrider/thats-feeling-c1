using UnityEngine;
using UnityEngine.Events;

using DataModel;
using Items;

namespace InteractFeatures.Interact
{
    public class CheckIsItemInHand : MonoBehaviour, IInteract
    {
        [SerializeField] private ItemInfo _item;

        [SerializeField] private UnityEvent _itemInHands;
        [SerializeField] private UnityEvent _itemIsNotInHands;
        
        public bool CanCheck;

        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
        }

        public void Interact()
        {
            if (!CanCheck)
            {
                Debug.Log($"Can't check item: {_item}, CanCheck = {CanCheck}");
                return;
            }

            if (_session.CheckIsParameterItemInHands(_item))
            {
                _itemInHands?.Invoke();
            }
            else
            {
                _itemIsNotInHands?.Invoke();
            }
        }
    }
}