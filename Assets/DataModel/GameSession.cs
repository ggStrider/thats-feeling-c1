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

        public bool CheckItem(GameObject item)
        {
            return _data.InventoryItems.Contains(item);
        }

        public bool CheckItem(string itemName)
        {
            return _data.InventoryItems.FirstOrDefault(item => item.name == itemName);
        }

        public void DeleteItem(string itemName, bool removeFromHands)
        {
            var itemToRemove = _data.InventoryItems.Find(item => item.name == itemName);

            if (itemToRemove == null) return;
            _data.InventoryItems.Remove(itemToRemove);

            if (!removeFromHands) return;
            if (_data.ObjectInHand == null) return;

            var go = _data.ObjectInHand;
            Destroy(go);
        }

        public void DeleteItem(GameObject item, bool removeFromHands)
        {
            if (!_data.InventoryItems.Contains(item)) return;
            _data.InventoryItems.Remove(item);

            if (!removeFromHands) return;
            if (_data.ObjectInHand == null) return;

            var go = _data.ObjectInHand;
            Destroy(go);
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