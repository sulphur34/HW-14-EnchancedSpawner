using UnityEngine;

[RequireComponent (typeof(WaypointsNavigator))]
[RequireComponent(typeof(TargetFollower))]
public class Follower : MonoBehaviour
{
    private Transform _waypointsContainer;
    private Transform _target;
    private TargetFollower _targetFollower;
    private Coroutine _coroutine;
    private float _minSpeed = 0.5f;
    private float _maxSpeed = 0.9f;

    private void OnDestroy()
    {
        StopCoroutine(_coroutine);
    }

    public void Init(Transform waypointsContainer, Transform target)
    {
        _waypointsContainer = waypointsContainer;
        var speed = Random.Range(_minSpeed,_maxSpeed);
        _target = target;
        bool isCycleMovement = false;
        GetComponent<WaypointsNavigator>().Init(_waypointsContainer, speed, isCycleMovement);
        _targetFollower = GetComponent<TargetFollower>();
        _targetFollower.Init(_target, speed);
        GetComponent<WaypointsNavigator>().RootEnded += FollowTarget;
    }

    private void FollowTarget()
    {
        _coroutine = StartCoroutine(_targetFollower.MoveToTarget());
    }

    
}
