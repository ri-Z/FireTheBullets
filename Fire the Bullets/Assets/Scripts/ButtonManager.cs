using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    //Restart
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Main Menu
    public void GoToMainMenu(){
        SceneManager.LoadScene(0);
    }
    public void GoToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    //Quit
    public void Quit(){
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
