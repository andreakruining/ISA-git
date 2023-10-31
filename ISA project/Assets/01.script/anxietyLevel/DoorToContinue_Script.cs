using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToContinue_Script : MonoBehaviour
{
    void OnTriggerEnter(Collider end)
    {
        if (end.gameObject.tag == "Player")
        {
            Debug.Log("next level");
        }
    }
}
