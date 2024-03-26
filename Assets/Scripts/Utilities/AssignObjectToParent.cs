using UnityEngine;

namespace Utilities
{
    public class AssignObjectToParent : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private Transform[] _objectsToAdopt;

        public void _AdoptAll()
        {
            if(_parent == null) return;
            
            foreach (var newChild in _objectsToAdopt)
            {
                newChild.SetParent(_parent);
            }
        }

        public void _AdoptByIndex(int index)
        {
            if(_parent == null) return;
            
            _objectsToAdopt[index]?.SetParent(_parent);
        }
    }
}