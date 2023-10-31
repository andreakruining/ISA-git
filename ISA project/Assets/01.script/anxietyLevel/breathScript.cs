using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breathScript : MonoBehaviour
{
    public AnxietyScore anxietyScript;
    public TimeController timeContScript;

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anxietyScript.AddScore(1);
            timeContScript.Countdown(5);
            Destroy(gameObject);
        }
    }
}
