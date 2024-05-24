using System;
using DataModel;
using Items;
using UnityEngine;

namespace InteractFeatures.Interact
{
    public class RemoveItemFromHands : MonoBehaviour, IInteract
    {
        [SerializeField] private ItemInfo _item;
        public bool CanRemove = true;

        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
        }

        public void Interact()
        {
            if (!CanRemove)
            {
                Debug.Log($"Can't remove item {_item}. CanRemove = {CanRemove}");
                return;
            }
            
            _session.RemoveItemFromHands(_item);
        }
    }
}