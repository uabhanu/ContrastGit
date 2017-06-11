using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndgameSceneManager : MonoBehaviour {

    public static EndgameSceneManager endgameManager;

    public bool horrorPlayerWon;

    void Awake () {
        if (EndgameSceneManager.endgameManager == null) {
            EndgameSceneManager.endgameManager = this;
        }
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadEndGameScene () {

    }
}
