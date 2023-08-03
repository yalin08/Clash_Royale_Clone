using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PawnAnimations : NetworkBehaviour
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
        if (IsClient) return;
        shooter.ShootBullet();
    }

    public void CancelAttack()
    {
        if (IsClient) return;
        animator.SetBool("CancelAttack", true);
    }
    public void FireAnim()
    {
        if (IsClient) return;


            animator.speed = 1 / shooter.stats.stat.attackPerSecond;
            animator.SetBool("Attack", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", false);
            animator.SetBool("CancelAttack", false);
           
           
    }

    public void IdleAnim()
    {
        if (IsClient) return;
        animator.speed = 1;
        animator.SetBool("Idle", true);
        animator.SetBool("Walk", false);
        animator.SetBool("Attack", false);
    }
    public void WalkAnim()
    {
        if (IsClient) return;
        animator.speed = 1;
        animator.SetBool("Walk", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Attack", false);
    }
}

