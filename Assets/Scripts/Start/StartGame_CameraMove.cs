using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame_CameraMove : MonoBehaviour {

    private float speedZ = 8;
    private float speedY = 0.9f;
    private float speedR = 8;
    private float endY = 32;
    private float endZ = -20;

    private void Update()
    {
        if (transform.position.y > endY)
        {
            transform.Translate(Vector3.down * speedY * Time.deltaTime);
            if (transform.position.z < endZ)
            {
                transform.Translate(Vector3.forward * speedZ * Time.deltaTime);
            }
        }
        else
        {
            if (transform.rotation.x > Quaternion.Euler(-12, 0, 0).x)
            {
                transform.Rotate(Vector3.left * speedR * Time.deltaTime);
            }
        }
    }
}
