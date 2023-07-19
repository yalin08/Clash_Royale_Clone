using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UnitShooter : MonoBehaviour
{
    public GameObject bulletPrefab;

    UnitStats stats;
    public Transform target;

    private void Awake()
    {
        stats = GetComponent<UnitStats>();
    }


    private void Update()
    {
        if (target == null)
            return;
        float distance = Vector3.Distance(target.position, transform.position);
      
        if (distance < stats.stat.attackRange)
        {
            if (stats.stat.canAttack)
            {
                ShootBullet();
            }
        }
    }


    void ShootBullet()
    {
       
        GameObject bulletObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
        BulletScript bullet = bulletObject.GetComponent<BulletScript>();
        bullet.damage = stats.stat.damage;
        bullet.speed = stats.stat.bulletSpeed;
        bullet.EnemyFaction = stats.enemyFaction;
        bulletObject.transform.transform.LookAt(target);

        stats.stat.canAttack = false;
        Destroy(bulletObject, 1f);
    }

}
