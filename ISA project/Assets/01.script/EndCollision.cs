using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision end)
    {
        if(end.collider.tag == "end")
        {
            Debug.Log("next level");
        }
    }

}
