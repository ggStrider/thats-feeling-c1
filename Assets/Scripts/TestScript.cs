using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private bool _canDoSomething;

    public void _SetCanDoSomething(bool canDoSomething)
    {
        _canDoSomething = canDoSomething;
    }
}