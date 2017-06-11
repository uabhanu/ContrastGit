using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorPlayerStats : MonoBehaviour {
    public static HorrorPlayerStats horrorPlayerStats;
    public int iCollectiblesGathered;
    public bool isBeingHeld = false;
    public GameObject gateObject;
    public int totalPetals;
    public bool hasOpenedTheGate = false;
    public GameObject lawnmower;
    public GameObject gateBush;
    public int grabCount = 0;

    private void Awake () {
        if (horrorPlayerStats == null) {
            horrorPlayerStats = this;
        }        
    }

    // Use this for initialization
    void Start () {
        gateObject = GameObject.FindGameObjectWithTag("Gate");
        totalPetals = GameObject.FindGameObjectsWithTag("HorrorCollectible").Length;
        iCollectiblesGathered = 0;
        isBeingHeld = false;
        grabCount = 0;
    }
	
	// Update is called once per frame
	void Update () {


		if(!hasOpenedTheGate) {
            if(iCollectiblesGathered >= totalPetals) {
                hasOpenedTheGate = true;
                gateObject.SetActive(false);
                gateBush.SetActive(false);
                lawnmower.SetActive(true);
            }
        }
        if (!isBeingHeld) {
            Vector3 pos = new Vector3(transform.position.x, 1 , transform.position.z);
            transform.position = pos;
            grabCount = 0;
        } else {
            if (Input.GetKeyDown(KeyCode.Space)) {
                grabCount++;
                if (grabCount >= 20) {
                    isBeingHeld = false;
                    PlayerController.player.m_enemyCollider.enabled = true;
                    PlayerController.player.m_enemyObj = null;
                    PlayerController.player.m_enemyCollider = null;
                }
            }
        }
	}

    private void OnCollisionEnter (Collision collision) {
        if (hasOpenedTheGate && collision.gameObject.CompareTag("HorrorExit")) {
            EndgameSceneManager.endgameManager.LoadEndGameScene(true);
        }
    }
}
