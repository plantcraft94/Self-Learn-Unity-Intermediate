using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] float damage;
	[SerializeField] int bulletCount;
	[SerializeField] Bullet bulletPrefab;
	[SerializeField] Transform BulletSpawnPoint;
	
	List<Bullet> bullets = new List<Bullet>(10);
	float FireTime;

    public void Fire(float fireRate)
    {
        FireTime -= Time.deltaTime;
        if (FireTime <= 0 && bullets.Count < 10)
        {
            Bullet bullet = Instantiate(bulletPrefab, BulletSpawnPoint.position, Quaternion.identity);
            bullets.Add(bullet);
            bullet.OnBulletDestroy.AddListener(DeleteBullet);
            FireTime = 1f / fireRate;
        }
    }

    void DeleteBullet(Bullet bullet)
	{
		bullets.Remove(bullet);
	}
	
}
