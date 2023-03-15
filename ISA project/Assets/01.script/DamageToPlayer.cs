using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    public int currentHealth;

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if(collisionInfo.GetComponent<Collider>().tag == "enemy")
        {
            TakeDamage(5);
            Debug.Log("the enemy is hitting you");
        }
    }
}
