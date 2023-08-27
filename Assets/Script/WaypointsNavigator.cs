using UnityEngine;
using UnityEngine.Events;

public class WaypointsNavigator : MonoBehaviour
{        

    public UnityAction RootEnded;
    private Transform[] _waypoint;
    private int _currentWaypointIndex;
    private float _speed; 
    private bool _isCircleMovement;

    private void Update()
    {
        var currentWaypoint = _waypoint[_currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, 
            currentWaypoint.position, _speed * Time.deltaTime);
        
        if (Vector2.Distance(transform.position,currentWaypoint.position) < 0.1)
            SwitchWaypoint();
    }

    public void Init(Transform waypointsContainer, float speed, bool isCircleMovement = true)
    {
        GetWaypoints(waypointsContainer);
        _isCircleMovement = isCircleMovement;
        _speed = speed;
    }

    private void SwitchWaypoint()
    {
        _currentWaypointIndex++;

        if (_currentWaypointIndex == _waypoint.Length)
        {
            if (_isCircleMovement)
                _currentWaypointIndex = 0;
            else
                RootEnded.Invoke();
        }
    }

    private void GetWaypoints(Transform waypointsContainer)
    {
        _waypoint = new Transform[waypointsContainer.childCount];

        for (int i = 0; i < waypointsContainer.childCount; i++)
            _waypoint[i] = waypointsContainer.GetChild(i).GetComponent<Transform>();
    }
}
