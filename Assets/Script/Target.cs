using UnityEngine;

[RequireComponent(typeof(WaypointsNavigator))]
public class Target : MonoBehaviour
{
    [SerializeField] private Transform _waypointsContainer;
    [SerializeField] private float _speed;

    private void Awake()
    {
        GetComponent<WaypointsNavigator>().Init(_waypointsContainer, _speed);
    }
}
