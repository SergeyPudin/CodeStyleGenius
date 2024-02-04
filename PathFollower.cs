using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _waypointContainer;
    
    private Transform[] _waypoints;
    private int _waypointIndex;

    private void Start()
    {
        _waypoints = new Transform[_waypointContainer.childCount];

        for (int i = 0; i < _waypointContainer.childCount; i++)
            _waypoints[i] = _waypointContainer.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform _targetWaypoint = _waypoints[_waypointIndex];

        LookAtWaypoint();
        transform.position = Vector3.MoveTowards(transform.position, _targetWaypoint.position, _moveSpeed * Time.deltaTime);

        if (transform.position == _targetWaypoint.position) 
            ChooseNextWaypoint();
    }

    private void ChooseNextWaypoint()
    {
        _waypointIndex++;

        if (_waypointIndex == _waypoints.Length)
            _waypointIndex = 0;
    }

    private void LookAtWaypoint()
    {
        Vector3 currentWaypointPosition = _waypoints[_waypointIndex].transform.position;

        transform.forward = currentWaypointPosition - transform.position;
    }
}