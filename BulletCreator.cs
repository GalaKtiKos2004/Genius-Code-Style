using System.Collections;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private WaypointFollower _target;

    private void Start()
    {
        StartCoroutine(ShootingWithDelay());
    }

    private IEnumerator ShootingWithDelay()
    {
        bool isWork = enabled;

        var wait = new WaitForSeconds(_delay);

        while (isWork)
        {
            Vector3 direction = (_target.transform.position - transform.position).normalized;
            Rigidbody bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            bullet.transform.up = direction;
            bullet.velocity = direction * _speed;

            yield return wait;
        }
    }
}