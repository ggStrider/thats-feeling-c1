using UnityEngine;

namespace Sounds
{
    public class PlayPhrases : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip[] _phrases;
    }
}