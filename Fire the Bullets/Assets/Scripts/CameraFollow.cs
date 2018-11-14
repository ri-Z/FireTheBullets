using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    private new Camera camera;

	void Start () {
        camera = GetComponent<Camera>();
	}
	
	void Update () {
        camera.orthographicSize = 5; //(Screen.height / 100f / 1f)

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(0, 0, -10f);
        }
    }
}
