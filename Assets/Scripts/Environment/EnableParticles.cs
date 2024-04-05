using UnityEngine;

using System.Collections.Generic;
using System.Linq;

namespace Environment
{
    public class EnableParticles : MonoBehaviour
    {
        [Tooltip("Leave it null == this game object")]
        [SerializeField] private GameObject _parent;

        private List<ParticleSystem> _particles;

        private void Awake()
        {
            _particles = _parent.GetComponentsInChildren<ParticleSystem>().ToList();

            foreach (var particle in _particles)
            {
                particle.Stop();
            }
            
            if (_parent != null) return;
            _parent = gameObject;
        }

        [ContextMenu("enable")]
        public void _EnableParticles()
        {
            foreach (var particle in _particles)
            {
                particle.Play();
            }
        }
    }
}