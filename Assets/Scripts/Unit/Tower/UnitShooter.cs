using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UnitShooter : MonoBehaviour
{
    public GameObject bulletPrefab;

    [HideInInspector] public UnitStats stats;
    public Transform target;
    PawnAnimations animations;
    private void Awake()
    {
        stats = GetComponent<UnitStats>();
        animations = GetComponentInChildren<PawnAnimations>();
    }


    private void Update()
    {
        if (target == null)
        {
            animations.CancelAttack();
            animations.WalkAnim();
            return;
        }
          
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance < stats.stat.attackRange)
        {
            animations.FireAnim();
        }
        else
        {
            animations.WalkAnim();
        }
    }


    public void ShootBullet()
    {

       // Debug.Log(gameObject.name);

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
