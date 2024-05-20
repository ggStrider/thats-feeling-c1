using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    [RequireComponent(typeof(GameSession))]
    public class CurrentGameSessionManager : MonoBehaviour
    {
        private List<string> _itemNames;
        
        private GameSession _gameSession;

        private void Start()
        {
            _gameSession = GetComponent<GameSession>();
        }

        public void _DeleteItem(string itemName)
        {
            _gameSession.DeleteItem(_itemNames.ToArray(), true);
        }

        public void _DeleteAllItems()
        {
            _gameSession.DeleteAllItems();
        }

        public void _GetArrayItems(List<string> itemArray)
        {
            _itemNames = itemArray;
        }
    }
}