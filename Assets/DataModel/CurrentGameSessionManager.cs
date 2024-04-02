using UnityEngine;

namespace DataModel
{
    [RequireComponent(typeof(GameSession))]
    public class CurrentGameSessionManager : MonoBehaviour
    {
        private GameSession _gameSession;

        private void Start()
        {
            _gameSession = GetComponent<GameSession>();
        }

        public void _DeleteItem(string itemName)
        {
            _gameSession.DeleteItem(itemName, true);
        }

        public void _DeleteAllItems()
        {
            _gameSession.DeleteAllItems();
        }
    }
}