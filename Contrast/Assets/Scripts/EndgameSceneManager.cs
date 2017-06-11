using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndgameSceneManager : MonoBehaviour {

    public static EndgameSceneManager endgameManager;

    public bool horrorPlayerWon;

    void Awake () {
        if (EndgameSceneManager.endgameManager == null) {
            EndgameSceneManager.endgameManager = this;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            LoadEndGameScene(true);
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            LoadEndGameScene(false);
        }
    }

    public void LoadEndGameScene (bool gameResult) {
        horrorPlayerWon = gameResult;
        if (horrorPlayerWon) {
            SceneManager.LoadScene("EndGameScreen_HorrorWins");
        } else {
            SceneManager.LoadScene("EndGameScreen_CutesyWins");
        }
    }

    /*
    void ChangeScreenMessages() {
        //switch between win or lose screens for each player
        Transform horrorCanvas = GameObject.FindGameObjectWithTag("HorrorCanvas").transform;
        Transform cutesyCanvas = GameObject.FindGameObjectWithTag("CutesyCanvas").transform;

        if(horrorPlayerWon) {
            horrorCanvas.GetChild(0).GetComponent<Image>().enabled = true;
            horrorCanvas.GetChild(1).GetComponent<Image>().enabled = false;
            cutesyCanvas.GetChild(0).GetComponent<Image>().enabled = false;
            cutesyCanvas.GetChild(1).GetComponent<Image>().enabled = true;
        } else {
            cutesyCanvas.GetChild(0).GetComponent<Image>().enabled = true;
            cutesyCanvas.GetChild(1).GetComponent<Image>().enabled = false;
            horrorCanvas.GetChild(0).GetComponent<Image>().enabled = false;
            horrorCanvas.GetChild(1).GetComponent<Image>().enabled = true;
        }
    }
    */
}
