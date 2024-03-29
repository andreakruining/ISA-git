using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepLvlPlayerMove : MonoBehaviour
{
    public float Speed = 3f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        moving();
    }

    private void moving()
    {
        Vector3 position = transform.position;

        if(Input.GetKey("w"))
        {
            position.z += Speed * Time.deltaTime;
        }

        transform.position = position;
    }
}
