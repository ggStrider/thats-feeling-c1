using UnityEngine;
using UnityEngine.Events;

namespace DataModel
{
    public class CheckItemInInventory : MonoBehaviour
    {
        [Header("You can check item by name or by game object")]
        public GameObject ItemObject;
        public string ItemName;
        
        [SerializeField] private bool _deleteAfterCheck;
        [SerializeField] private bool _removeFromHand;

        [SerializeField] private UnityEvent _onItemExist;
        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
        }

        public void _Check()
        {
            if(ItemObject == null && ItemName == string.Empty) return;

            if (ItemObject != null)
            {
                if(!_session.CheckItem(ItemObject)) return;
                _onItemExist?.Invoke();
                
                if (!_deleteAfterCheck) return;
                _session.DeleteItem(ItemObject, _removeFromHand);
            }
            
            else if (ItemName != string.Empty)
            {
                if(!_session.CheckItem(ItemName)) return;
                _onItemExist?.Invoke();
                
                if (!_deleteAfterCheck) return;
                _session.DeleteItem(ItemName, _removeFromHand);
            }
        }
    }
}