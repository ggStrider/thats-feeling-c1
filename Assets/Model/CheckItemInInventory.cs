using UnityEngine;
using UnityEngine.Events;

namespace Model
{
    public class CheckItemInInventory : MonoBehaviour
    {
        [Header("You can check item by name or by game object")]
        [SerializeField] private GameObject _item;
        [SerializeField] private string _itemName;
        
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
            if(_item == null && _itemName == string.Empty) return;

            if (_item != null)
            {
                if(!_session.CheckItem(_item)) return;
                _onItemExist?.Invoke();
                
                if (!_deleteAfterCheck) return;
                _session.DeleteItem(_item, _removeFromHand);
            }
            
            else if (_itemName != string.Empty)
            {
                if(!_session.CheckItem(_itemName)) return;
                _onItemExist?.Invoke();
                
                if (!_deleteAfterCheck) return;
                _session.DeleteItem(_itemName, _removeFromHand);
            }
        }
    }
}