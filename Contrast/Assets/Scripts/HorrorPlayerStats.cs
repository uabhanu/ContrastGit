using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorPlayerStats : MonoBehaviour {
    public static HorrorPlayerStats horrorPlayerStats;
    public int iCollectiblesGathered;

    private void Awake () {
        if (horrorPlayerStats == null) {
            horrorPlayerStats = this;
        }        
    }

    // Use this for initialization
    void Start () {
        iCollectiblesGathered = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
