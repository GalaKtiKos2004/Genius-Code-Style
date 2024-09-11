using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypointIndex;

    private void Update()
    {
        Vector3 currentWaypoint = _waypoints[_currentWaypointIndex].position;

        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, _speed * Time.deltaTime);

        if (transform.position == currentWaypoint)
        {
            _currentWaypointIndex = (++_currentWaypointIndex) % _waypoints.Length;
            RotateToWaypoint(_waypoints[_currentWaypointIndex].position);
        }
    }

    private void RotateToWaypoint(Vector3 waypoint)
    {
        Vector3 direction = (waypoint - transform.position).normalized;
        transform.forward = direction;
    }
}