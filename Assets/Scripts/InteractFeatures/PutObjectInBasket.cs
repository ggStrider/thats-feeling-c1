using DataModel;
using UnityEngine;

namespace InteractFeatures
{
    public class PutObjectInBasket : MonoBehaviour
    {
        [SerializeField] private string _basketGameObjectName = "Basket";
        
        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
        }

        public void _PutInBasket()
        {
            if(!_session.CheckItem(_basketGameObjectName)) return;

            transform.localPosition = _session.GetObjectInHand().transform.position + new Vector3(0, 0.3f, 0);
            gameObject.AddComponent<Rigidbody>();
        }
    }
}