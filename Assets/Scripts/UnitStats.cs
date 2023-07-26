using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UnitStats : MonoBehaviour
{
 

    public Factions faction;
     public Factions enemyFaction;
    public Stats stat;
    [Space]

    float timer;



    public GameObject HealthBar;

    public HealthBars healthBar;
    

    private void OnValidate()
    {
        stat.maxHealth = stat.health;
      
    }
    private void Awake()
    {
      


    }
    private void Start()
    {
        if (healthBar == null)
        {
            GameObject go = Instantiate(HealthBar, transform);
            healthBar = GetComponentInChildren<HealthBars>();

        }


        healthBar.slider.value = stat.health / stat.maxHealth;
        healthBar.healthText.text = "" + stat.health;

        healthBar.gameObject.SetActive(false);

    }

    private void Update()
    {
       /* if (!stat.canAttack)
        {
            timer += Time.deltaTime;
            if (timer >= stat.attackPerSecond)
            {
                timer = 0;
                stat.canAttack = true;
            }
        } */

    }

    public void TakeDamage(float damage)
    {
        stat.health -= damage;
        healthBar.slider.value = stat.health / stat.maxHealth;
        healthBar.healthText.text = ""+stat.health;
        healthBar.gameObject.SetActive(true);

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
    public float sightRange;

    public float bulletSpeed;

    public float speed;

    public bool canAttack = true;
    [Space]
    public bool canAttackAir;
    [Space]
    public bool AirUnit;

}