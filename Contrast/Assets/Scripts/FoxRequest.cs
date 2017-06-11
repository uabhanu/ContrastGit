using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxRequest : MonoBehaviour {

    public static FoxRequest foxRequest;
    public string currentRequest;
    public List<FlowerType> flowerList = new List<FlowerType>();
    public float pickupThreshold = 3.0f;

    private void Awake () {
        if (foxRequest == null) {
            foxRequest = this;
        }
    }

    // Use this for initialization
    void Start () {
        currentRequest = null;
        GenerateNextRequest();
        //Call bubble
        ChangeFlowerHead();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay (Collider other) {
        if(other.CompareTag("Enemy")) {
            print("Touching the flower");
        }
    }

    public void GenerateNextRequest() {
        if (currentRequest != null) {
            flowerList.RemoveAt(0);
        }
        currentRequest = flowerList[0].flowerType;
        //TODO: generate speech bubble with correct flower head
    }

    public void DeliveryFeedback (bool correctDelivery) {
        if(correctDelivery) {
            print("Correct Delivery");
        } else {
            print("WRONG!");
        }
    }

    public void ChangeFlowerHead() {
        print("Get me a " + currentRequest + "flower.");
    }
}
