using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(UnitCollisionController))]
public class UnitStats : MonoBehaviour
{
 

    public Factions faction;
    [HideInInspector] public Factions enemyFaction;
    public Stats stat;
    [Space]
    [Space]
    public bool AirUnit;
    float timer;



    public GameObject HealthBar;

    public HealthBars healthBar;
    

    private void OnValidate()
    {
        stat.maxHealth = stat.health;
  
    }
    private void Awake()
    {
        if (healthBar == null)
        {
            GameObject go = Instantiate(HealthBar, transform);
            healthBar = GetComponentInChildren<HealthBars>();
            enemyFaction = TowersManager.Instance.EnemyFaction(faction);
        }


        healthBar.slider.value = stat.health / stat.maxHealth;
    }

    private void Update()
    {
        if (!stat.canAttack)
        {
            timer += Time.deltaTime;
            if (timer >= stat.attackPerSecond)
            {
                timer = 0;
                stat.canAttack = true;
            }
        }

    }

    public void TakeDamage(float damage)
    {
        stat.health -= damage;
        healthBar.slider.value = stat.health / stat.maxHealth;
        if (stat.health <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
public enum Factions
{
    Blue, Red
}
[System.Serializable]
public class Stats
{
    public float health;
    public float maxHealth;


    public float damage;
    public float attackPerSecond;
    public float attackRange;

    public float bulletSpeed;

    public float speed;

    public bool canAttack = true;

}