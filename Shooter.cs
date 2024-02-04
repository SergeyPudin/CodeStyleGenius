using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _objectToShoot;
    [SerializeField] float _timeBetweenShots;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Rigidbody bulletRigidbody;
            Vector3 direction = (_objectToShoot.position - transform.position).normalized;

            Bullet newBullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            if (newBullet.TryGetComponent(out bulletRigidbody))
            {
                bulletRigidbody.transform.up = direction;
                bulletRigidbody.velocity = direction * _bulletSpeed;
            }

            yield return new WaitForSeconds(_timeBetweenShots);
        }
    }
}