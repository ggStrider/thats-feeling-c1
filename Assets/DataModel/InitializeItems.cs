using UnityEngine;

using System.Collections.Generic;
using Items;
using UI;

namespace DataModel
{
    public class InitializeItems : MonoBehaviour
    {
        [SerializeField] private List<InventorySlotShowInfo> _slots;
        
        private GameSession _session;
        
        private void Start()
        {
            _session = GetComponent<GameSession>();
            _Initialize();
        }

        public void _AddToUI(ItemInfo item)
        {
            var slot = FindFreeSlot();

            if (slot == null)
            {
                Debug.Log("No free slots! / Didnt add slots to array");
                return;
            }

            slot.CurrentItem = item;
            slot.ReDrawItemInInventory();
        }

        private InventorySlotShowInfo FindFreeSlot()
        {
            foreach (var slot in _slots)
            {
                if (slot.CurrentItem != null) continue;
                return slot;
            }

            return null;
        }
        
        [ContextMenu("Initialize")]
        public void _Initialize()
        {
            var items = _session.Data.Items;

            if (items.Count == 0) return;
        }
    }
}
