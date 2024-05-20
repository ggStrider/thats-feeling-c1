using UnityEngine;
using UnityEngine.Events;

namespace DataModel
{
    public class CheckItemInInventory : MonoBehaviour
    {
        [Header("You can check item by name or by game object")]
        public GameObject[] ItemsObject;
        public string[] ItemsName;
        
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
            if(ItemsObject.Length == 0 && ItemsName.Length == 0) return;

            if (ItemsObject.Length > 0)
            {
                if(!_session.CheckItems(ItemsObject)) return;
                _onItemExist?.Invoke();
                
                if (!_deleteAfterCheck) return;
                _session.DeleteItem(ItemsObject, _removeFromHand);
            }
            
            else if (ItemsName.Length > 0)
            {
                if(!_session.CheckItems(ItemsName)) return;
                _onItemExist?.Invoke();
                
                if (!_deleteAfterCheck) return;
                _session.DeleteItem(ItemsName, _removeFromHand);
            }
        }
    }
}