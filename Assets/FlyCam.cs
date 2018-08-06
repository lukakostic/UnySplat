using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCam : MonoBehaviour {
    public float sensitivity = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(-Input.GetAxis("Mouse Y")*sensitivity + transform.eulerAngles.x, Input.GetAxis("Mouse X")*sensitivity + transform.eulerAngles.y, 0);
	}

    private void FixedUpdate()
    {
        float y = 0;
        if (Input.GetKey(KeyCode.Space)) y = 1;
        if (Input.GetKey(KeyCode.LeftShift)) y = -1;
        Vector3 m = new Vector3(Input.GetAxisRaw("Horizontal"), y, Input.GetAxisRaw("Vertical"));
        m *= 0.2f;
        transform.Translate(m, Space.Self);
    }
}
