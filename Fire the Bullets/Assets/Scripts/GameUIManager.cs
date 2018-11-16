using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

    public static GameUIManager instance;

    public Text playerLife;
	public Text playerScore;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

	void Update(){
		if( GameManager.instance.player != null ){
			playerScore.text = GameManager.instance.player.currentScore.ToString();
		}
	}

    public void UpdatePlayerLife()
    {
        playerLife.text = GameManager.instance.player.currentLife.ToString();
    }

    public void UpdateBaseLife()
    {
        playerLife.text = GameManager.instance.player.currentLife.ToString();
	}
}
