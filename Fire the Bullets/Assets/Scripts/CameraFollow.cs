using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private new Camera camera;

	void Start () {
        camera = GetComponent<Camera>();
	}
	
	void Update () {
        camera.orthographicSize = 10; //(Screen.height / 100f / 1f)

		if (GameManager.instance.player != null)
        {
			transform.position = Vector3.Lerp(transform.position, GameManager.instance.player.transform.position, 0.1f) + new Vector3(0, 0, -10f);
        }
    }
}
