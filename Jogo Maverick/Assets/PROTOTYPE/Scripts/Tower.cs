using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootForce = 1000f;
    [SerializeField] private float cooldownTime = 1f;
    private float lastShootTime;

    private void Start()
    {
        lastShootTime = Time.time;
    }

    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);

            if (target.position.y < 100 && Time.time >= lastShootTime + cooldownTime)
            {
                Shoot();
                lastShootTime = Time.time;
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }
}