using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

namespace Menu
{
    public class OnIntroEndAction : MonoBehaviour
    {
        [Tooltip("Leave it alone = gameObject")]
        [SerializeField] private GameObject _videoParent;
        [SerializeField] private Fader _fader;

        [SerializeField] private UnityEvent _onVideoEnded;

        private void Awake()
        {
            _fader.gameObject.SetActive(false);

            if (_videoParent == null)
            {
                _videoParent = gameObject;
            }
            var delay = _videoParent.GetComponentInChildren<VideoPlayer>().clip.length;
            Invoke(nameof(OnIntroEnded), (float)delay + 0.1f);
        }

        private void OnIntroEnded()
        {
            _fader.gameObject.SetActive(true);
            _fader._OnUnFade();

            var playerController = FindObjectOfType<MenuInputController>();
            playerController._EnableMap();
            
            _onVideoEnded?.Invoke();
            
            _videoParent.SetActive(false);
        }
    }
}