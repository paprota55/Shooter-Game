using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Class to move/rotate object (arm with gun)
public class ArmRotating : MonoBehaviour
{
    ///start rotation offset
    public int offset = 0;
    

    ///Rotate arm dependent from mouse position
    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle + offset);
        
    }
}
