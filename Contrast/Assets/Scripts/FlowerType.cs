using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerType : MonoBehaviour {

    public string flowerType;
    public bool hasBeenDropped;

	// Use this for initialization
	void Start () {
        hasBeenDropped = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (hasBeenDropped) {
            float distanceToFox = Vector3.Distance(transform.position, FoxRequest.foxRequest.transform.position);
            print(distanceToFox);
            if(distanceToFox <= FoxRequest.foxRequest.pickupThreshold) {
                print("IS FOX");
                FoxRequest foxComp = FoxRequest.foxRequest.GetComponent<FoxRequest>();
                //Check against fox request

                //remove the object from the flower storage
                if (flowerType == foxComp.currentRequest) {
                    foxComp.DeliveryFeedback(true);
                } else {
                    foxComp.DeliveryFeedback(false);
                }
                foxComp.GenerateNextRequest();
                //destroy the object
                Destroy(gameObject);
            }
        }

    }
}
