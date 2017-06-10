using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adapt to the CuteseyPlayer
public class PickupCollectible : MonoBehaviour {
    [SerializeField]
    private bool bPickupNeedsInput = false;
    [SerializeField]
    private bool b_IsPickupAvailable;
    [SerializeField]
    private GameObject o_AvailableCollectible;

    // Use this for initialization
    void Start () {
        b_IsPickupAvailable = false;

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)) {
            if(b_IsPickupAvailable && o_AvailableCollectible != null) {
                PickupObject();
            }
        }
	}

    private void OnTriggerEnter (Collider other) {
        if(other.gameObject.CompareTag("HorrorCollectible")) {
            b_IsPickupAvailable = true;
            o_AvailableCollectible = other.gameObject;
            if(!bPickupNeedsInput) {
                PickupObject();
            }
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.gameObject.CompareTag("HorrorCollectible")) {
            if (o_AvailableCollectible != null) {
                if (other.gameObject == o_AvailableCollectible) {
                    o_AvailableCollectible = null;
                    b_IsPickupAvailable = false;
                }
            }
        }
    }

    private void PickupObject () {
        Debug.Log("Picked up Collectible");
        b_IsPickupAvailable = false;
        Destroy(o_AvailableCollectible);
        HorrorPlayerStats.horrorPlayerStats.iCollectiblesGathered += 1;
    }
}
