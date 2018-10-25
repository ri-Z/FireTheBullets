using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    [SerializeField]
    public bool pause;

	void Start () {
        pause = false;
	}
	
	void Update () {
        if (Input.GetKeyDown("p"))
        {
            if (!pause){
                Debug.Log("pause");
                pause = true;
                Time.timeScale = 0;
            } else{
                pause = false;
                Time.timeScale = 1;
            }
        }
    }
}
