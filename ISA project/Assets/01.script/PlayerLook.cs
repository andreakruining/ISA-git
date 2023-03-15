using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float rotationSpeed = 300f;

    // Update is called once per frame
    void Update()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        //worldMousePosition.y = 0;
        //transform.rotation = Quaternion.LookRotation(worldMousePosition - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(worldMousePosition - transform.position), rotationSpeed * Time.deltaTime);
    }
}
