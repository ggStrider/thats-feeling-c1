using UnityEngine;
using UnityEngine.Events;

using DataModel;
using Items;

namespace InteractFeatures.Interact
{
    public class CheckForItemsInInventory : MonoBehaviour, IInteract
    {
        [SerializeField] private ItemInfo[] _items;

        [Space] [SerializeField] private UnityEvent _onInventoryContainsItems;
        [SerializeField] private UnityEvent _onInventoryDoesntContainsItems;

        [Space] [SerializeField] private bool _disableIfExist;
        public bool CanCheck = true;

        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
        }

        [ContextMenu("check")]
        public void Interact()
        {
            if (!CanCheck)
            {
                Debug.Log($"Can't check here: {this} right now! Checker : {gameObject}");
                return;
            }

            if (_session.IsInventoryContainsParameterItems(_items))
            {
                _onInventoryContainsItems?.Invoke();

                if (_disableIfExist)
                {
                    enabled = false;
                }
            }
            else
            {
                _onInventoryDoesntContainsItems?.Invoke();
                Debug.LogWarning($"Inventory doesn't contains this items. Checker: {gameObject} .");
            }
        }
    }
}