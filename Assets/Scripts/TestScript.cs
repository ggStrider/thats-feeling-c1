using System.Collections;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private float _myValue = 1;

    [ContextMenu("change")]
    void onchange()
    {
        StartCoroutine(change());
    }

    IEnumerator change()
    {
        while (_myValue > 0)
        {
            _myValue = Mathf.Clamp01(_myValue - 0.01f);
            Debug.Log(_myValue);
            yield return null;
        }
    }
}