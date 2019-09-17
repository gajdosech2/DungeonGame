using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public bool lockCursor = true;
    private bool lookBack = false;
    private Vector3 normalPosition = new Vector3(0, 7, -8);
    private Vector3 lookBackPosition = new Vector3(0, 5, 6);
    private Quaternion normalRotation = Quaternion.Euler(25, 0, 0);
    private Quaternion lookBackRotation = Quaternion.Euler(25, 180, 0);

    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (lookBack == false)
            {
                transform.localRotation = lookBackRotation;
                transform.localPosition = lookBackPosition;
            }
            lookBack = true;
        }
        else if (lookBack)
        {
            transform.localRotation = normalRotation;
            transform.localPosition = normalPosition;
            lookBack = false;
        }  
    }
}
