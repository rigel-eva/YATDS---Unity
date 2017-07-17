using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    public GameObject target;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
            Cursor.lockState = CursorLockMode.Locked;
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            OrbitCamera(target.transform.position, mouseX, mouseY);
    }
    public void OrbitCamera(Vector3 target, float y_rotate, float x_rotate)
    {
        Vector3 angles = transform.eulerAngles;
        angles.z = 0;
        transform.eulerAngles = angles;
        transform.RotateAround(target, Vector3.up, y_rotate);
        transform.RotateAround(target, Vector3.left, x_rotate);

        transform.LookAt(target);
    }
}
