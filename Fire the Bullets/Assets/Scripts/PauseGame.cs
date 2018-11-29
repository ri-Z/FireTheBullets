using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    public bool pause;

	void Start () {
        pause = false;
        Unpause();
	}
	
	void Update () {
        if (Input.GetKeyDown("p") && pause == false)
        {
            Debug.Log("pause");
            pause = true;
            Pause();
        } else {
            if (Input.GetKeyDown("p"))
            {
                Debug.Log("unpause");
                pause = false;
                Unpause();
            }
        }
    }

    public void Unpause(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
