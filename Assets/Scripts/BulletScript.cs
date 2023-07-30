using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage;
    public float speed;
    public Factions EnemyFaction;
    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger == false)
        {
            if (other.GetComponent<UnitStats>() != null)
            {
                UnitStats UnitStats = other.GetComponent<UnitStats>();
                if (UnitStats.faction.Value == EnemyFaction)
                {
                    UnitStats.TakeDamage(damage);
                    Destroy(gameObject);
                }
            }
        }
     
    }

}
