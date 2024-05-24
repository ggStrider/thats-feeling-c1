using UnityEngine;
using UnityEngine.Events;

using DataModel;
using Items;

namespace InteractFeatures.Interact
{
    public class TakeItem : MonoBehaviour, IInteract
    {
        [SerializeField] private ItemInfo _item;
        public bool CanTake = true;
        
        [Space]
        [SerializeField] private bool _takeInHand;
        [SerializeField] private Transform _handPlace;

        [Space]
        [SerializeField] private UnityEvent _onItemTook;

        [Space]
        [SerializeField] private bool _disableGameObjectWhenTook;
        
        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
        }

        // Take item method
        [ContextMenu("Interact")]
        public void Interact()
        {
            if (!CanTake)
            {
                Debug.LogWarning($"Can't take {_item}, here: {this} right now!");
                return;
            }

            _session.AddItem(_item);

            if (_takeInHand)
            {
                var putInHand = Instantiate(_item.ItemWhenTakeInHand, _handPlace);
                putInHand.transform.localScale = _item.SizeInHand;
                putInHand.transform.localRotation = Quaternion.Euler(_item.RotationOffsetInHand);

                _session.TakeToHands(_item);
            }
            
            _onItemTook?.Invoke();
            enabled = false;

            if (!_disableGameObjectWhenTook) return;
            gameObject.SetActive(false);
        }
    }
}