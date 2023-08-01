using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class BulletScript : NetworkBehaviour
{
    public float damage;
    public float speed;
    public Factions EnemyFaction;

    private void Start()
    {
        Invoke("DestroySelf", 1);
    }
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
                    DestroySelf();
                }
            }
        }
     
    }


    private void DestroySelf()
    {
        if(IsServer)
        Destroy(gameObject);
        if (IsOwner)
        DestroyServerRpc();
    }

    [ServerRpc]
    void DestroyServerRpc()
    {

      
        GetComponent<NetworkObject>().Despawn(true);
    }

}
