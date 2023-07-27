using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnAnimations : MonoBehaviour
{
    public UnitShooter shooter;

    public Animator animator;
    private void Awake()
    {
        shooter = GetComponentInParent<UnitShooter>();
        animator = GetComponent<Animator>();
    }

    public void Fire()
    {
        shooter.ShootBullet();
    }

    public void CancelAttack()
    {
        animator.SetBool("CancelAttack", true);
    }
    public void FireAnim()
    {
        animator.speed = 1/shooter.stats.stat.attackPerSecond;
        animator.SetBool("Attack",true);
        animator.SetBool("Idle", false);
        animator.SetBool("Walk", false);
        animator.SetBool("CancelAttack", false);
    }
    public void IdleAnim()
    {
        animator.speed = 1;
        animator.SetBool("Idle", true);
        animator.SetBool("Walk", false);
        animator.SetBool("Attack", false);
    }
    public void WalkAnim()
    {
        animator.speed = 1;
        animator.SetBool("Walk", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Attack", false);
    }
}

