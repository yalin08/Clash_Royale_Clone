using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class UnitStats : NetworkBehaviour
{


    public NetworkVariable<Factions> faction;
    public NetworkVariable<Factions> enemyFaction;
    public Stats stat;
    [Space]

    float timer;



    public GameObject HealthBar;

    public HealthBars healthBar;


    private void OnValidate()
    {
        stat.maxHealth = stat.health;

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


    }

    public void TakeDamage(float damage)
    {
        stat.health -= damage;
        if (IsServer)
            TakeDamageClientRpc(stat.health);
        healthBar.slider.value = stat.health / stat.maxHealth;
        healthBar.healthText.text = "" + stat.health;
        healthBar.gameObject.SetActive(true);

        if (stat.health <= 0)
        {
            Die();
        }

    }


    [ClientRpc]
    void TakeDamageClientRpc(float health)
    {
        stat.health = health;
        healthBar.slider.value = stat.health / stat.maxHealth;
        healthBar.healthText.text = "" + stat.health;
        healthBar.gameObject.SetActive(true);
    }

    public virtual void Die()
    {
        if (IsServer)
            GetComponent<NetworkObject>().Despawn(true);
        if (IsOwner)
            DieServerRpc();
    }
    [ServerRpc]
    void DieServerRpc()
    {


    }

}
public enum Factions
{
    Blue, Red, none
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