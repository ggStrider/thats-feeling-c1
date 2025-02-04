using UnityEngine;
using Items;

using System.Linq;

namespace DataModel
{
    [RequireComponent(typeof(InitializeItems))]
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        public PlayerData Data => _data;

        private InitializeItems _initializeItems;

        private void Awake()
        {
            _initializeItems = GetComponent<InitializeItems>();
            
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

        #region Refactored
        public void AddItem(ItemInfo itemInfo)
        {
            _data.Items.Add(itemInfo);
            _initializeItems._AddToUI(itemInfo);
        }

        public void TakeToHands(ItemInfo objectToTake)
        {
            if (objectToTake == null)
            {
                Debug.LogWarning($"Object to take is null. It's here {this}");
            }

            if (_data.ObjectInHand != null)
            {
                Debug.LogWarning($"Already have object in hand!");
            }
            _data.ObjectInHand = objectToTake.ItemWhenTakeInHand;
        }

        public bool IsInventoryContainsParameterItems(ItemInfo[] items)
        {
            foreach (var item in items)
            {
                if (!_data.Items.Contains(item)) return false;
            }

            return true;
        }
        
        public bool IsInventoryContainsParameterOneItem(ItemInfo item)
        { 
            return _data.Items.Contains(item);
        }

        public void DeleteItem(ItemInfo item)
        {
            if (!_data.Items.Contains(item))
            {
                Debug.LogWarning($"Inventory doesn't contain {item}");
                return;
            }

            _data.Items.Remove(item);

            if (_data.ObjectInHand != item.ItemWhenTakeInHand) return;

            RemoveItemFromHands(item);
        }

        public bool CheckIsParameterItemInHands(ItemInfo item)
        {
            return _data.ObjectInHand == item.ItemWhenTakeInHand;
        }

        public void RemoveItemFromHands(ItemInfo item)
        {
            if (!CheckIsParameterItemInHands(item))
            {
                Debug.LogWarning($"Item {item.ItemWhenTakeInHand} not in hand! Item: {item}");
                return;
            }
            
            var objectInHand = _data.ObjectInHand;
            _data.ObjectInHand = null;
            Destroy(objectInHand);
        }

        public void ReplaceItemByAnotherItem(ItemInfo whichItemReplace, ItemInfo itemToSetAsNew)
        {
            if (!IsInventoryContainsParameterOneItem(whichItemReplace))
            {
                Debug.LogWarning($"Inventory doesn't contains {whichItemReplace} ! Checker: {gameObject}");
                return;
            }

            var index = _data.Items.IndexOf(whichItemReplace);
            _data.Items[index] = itemToSetAsNew;
        }
        
        public void DeleteAllItems()
        {
            _data.Items.Clear();
        }
        #endregion

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