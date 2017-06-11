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
	}
}
