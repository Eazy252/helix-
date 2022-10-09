using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderRotation : MonoBehaviour
{
    public float rotationSpeed;
    void Start()
    {   // This code locke's the Visibility of the mouse while playing the game
      //  Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){ 
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(0,mouseX * -rotationSpeed + Time.deltaTime, 0 );
        }
    }
}
