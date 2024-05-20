using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DataModel
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        public PlayerData Data => _data;

        private void Awake()
        {
            if (IsSessionsExist())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
            }
        }

        private bool IsSessionsExist()
        {
            var sessions = FindObjectsOfType<GameSession>();

            return sessions.Any(oneSession => oneSession != this);
        }

        public void AddItem(GameObject item, bool takeToHands)
        {
            _data.InventoryItems.Add(item);

            if (!takeToHands) return;
            _data.ObjectInHand = item;
        }

        public bool CheckItems(GameObject[] items)
        {
            if (_data.InventoryItems.Count == 0) return false;

            foreach (var item in items)
            {
                if (!_data.InventoryItems.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckItems(string[] itemsName)
        {
            if (_data.InventoryItems.Count == 0) return false;
            
            foreach (var itemObject in _data.InventoryItems)
            {
                foreach (var itemName in itemsName)
                {
                    if (itemObject.name == itemName) return true;
                }
            }

            return false;
        }

        public void DeleteItem(string[] itemNames, bool removeFromHands)
        {
            var itemsToRemove = _data.InventoryItems.FindAll(item => itemNames.Contains(item.name));

            if (itemsToRemove.Count == 0) return;

            foreach (var item in itemsToRemove)
            {
                _data.InventoryItems.Remove(item);
            }

            if (!removeFromHands) return;
            if (_data.ObjectInHand == null) return;

            var containsObject = false;

            foreach (var item in itemsToRemove)
            {
                if (item != _data.ObjectInHand) continue;
                
                containsObject = true;
                break;
            }

            if (!containsObject) return;

            var objectInHand = _data.ObjectInHand;
            Destroy(objectInHand);
        }

        public void DeleteItem(GameObject[] items, bool removeFromHands)
        {
            var itemsToDelete = new List<GameObject>();
            foreach (var item in items)
            {
                if (!_data.InventoryItems.Contains(item)) continue;
                itemsToDelete.Add(item);
            }

            foreach (var item in itemsToDelete)
            {
                _data.InventoryItems.Remove(item);
            }

            if (!removeFromHands) return;
            if (_data.ObjectInHand == null) return;

            foreach (var item in itemsToDelete)
            {
                if(item == _data.ObjectInHand)
                    Destroy(item);
            }
        }

        public void DeleteAllItems()
        {
            _data.InventoryItems.Clear();
        }

        public GameObject GetObjectInHand()
        {
            return _data.ObjectInHand;
        }

        public void MakeDecision(int index)
        {
            _data.Decisions.Add(index);
        }

        public int GetDecision(int index)
        {
            return _data.Decisions[index];
        }
    }
}