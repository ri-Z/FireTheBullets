using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Transform playerSpawnPoint;
    public GameObject playerPrefab;
    public Player player;

    public Transform baseSpawnPoint;
    public GameObject basePrefab;
    public Base baseObject;

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

        GameSetup();
    }

    private void GameSetup()
    {
        SpawnPlayer();
        SpawnBase();
    }

    void SpawnPlayer()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
        Player player = playerGO.GetComponent<Player>();

        this.player = player;
    }

    void SpawnBase(){
        GameObject baseGO = Instantiate(basePrefab, baseSpawnPoint.position, Quaternion.identity);
        Base baseObject = baseGO.GetComponent<Base>();

        this.baseObject = baseObject;
    }

	public void GameOver(){
		string s = PlayerPrefs.GetString("FTB_SCORE_1");
		float score1 = float.Parse( PlayerPrefs.GetString("FTB_SCORE_1") == "" ? "0" : PlayerPrefs.GetString("FTB_SCORE_1") );
		float score2 = float.Parse( PlayerPrefs.GetString("FTB_SCORE_2") == "" ? "0" : PlayerPrefs.GetString("FTB_SCORE_2") );
		float score3 = float.Parse( PlayerPrefs.GetString("FTB_SCORE_3") == "" ? "0" : PlayerPrefs.GetString("FTB_SCORE_3") );

		if( score1 == 0 || score1 <= player.currentScore ){
			PlayerPrefs.SetString("FTB_SCORE_1", player.currentScore.ToString());
		}else if( score2 == 0 || score2 <= player.currentScore ){
			PlayerPrefs.SetString("FTB_SCORE_2", player.currentScore.ToString());
		}else if( score3 == 0 || score3 <= player.currentScore ){
			PlayerPrefs.SetString("FTB_SCORE_3", player.currentScore.ToString());
		}

		SceneManager.LoadScene("GameOver");
	}
}
