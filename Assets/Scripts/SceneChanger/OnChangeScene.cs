using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneChanger
{
    public class OnChangeScene : MonoBehaviour
    {
        [SerializeField] private string _sceneName;

        public void _ChangeScene()
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}