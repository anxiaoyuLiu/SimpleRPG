using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private Transform player;
    private Vector3 offset;
    private float distence;
    private float scrollSpeed = 5;
    private bool isRightMouseDown = false;
    private float rotateSpeed = 2;

	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        offset = transform.position - player.position;
        distence = offset.magnitude;
        transform.LookAt(player.position);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position + offset;
        ScrollView();
        RotateView();
	}

    private void ScrollView()
    {
        distence = distence - Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distence = Mathf.Clamp(distence, 3, 18);
        offset = offset.normalized * distence;
    }

    private void RotateView()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRightMouseDown = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRightMouseDown = false;
        }
        if (isRightMouseDown)
        {
            transform.RotateAround(player.position, Vector3.up, Input.GetAxis("Mouse X") * rotateSpeed);

            Vector3 originalPosition = transform.position;//保存相机的原始位置信息
            Quaternion originalrotation = transform.rotation;
            transform.RotateAround(player.position, -transform.right, Input.GetAxis("Mouse Y") * rotateSpeed);
            float x = transform.eulerAngles.x;
            if (x < 20 || x > 70)
            {
                transform.position = originalPosition;
                transform.rotation = originalrotation;
            }

            offset = transform.position - player.position;
            distence = offset.magnitude;
        }
    }
}
