using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour {
	public Text score1Value, score2Value, score3Value;

	void Start(){
		score1Value.text = PlayerPrefs.GetString("FTB_SCORE_1");
		score2Value.text = PlayerPrefs.GetString("FTB_SCORE_2");
		score3Value.text = PlayerPrefs.GetString("FTB_SCORE_3");
	}

	public void GoToMenu(){
		SceneManager.LoadScene("MainMenu");
	}
}
