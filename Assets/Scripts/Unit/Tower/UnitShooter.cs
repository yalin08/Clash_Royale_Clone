using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Netcode;
public class UnitShooter : NetworkBehaviour
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

        if (!IsServer) return;

        Debug.Log("Shot bullet");

        GameObject bulletObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
        BulletScript bullet = bulletObject.GetComponent<BulletScript>();
        bullet.damage = stats.stat.damage;
        bullet.speed = stats.stat.bulletSpeed;
        bullet.EnemyFaction = stats.enemyFaction.Value;
        bulletObject.transform.transform.LookAt(target);

        bullet.GetComponent<NetworkObject>().Spawn();

        stats.stat.canAttack = false;

    }

 



}
