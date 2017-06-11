using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxRequest : MonoBehaviour {

    public static FoxRequest foxRequest;
    public string currentRequest;
    public List<FlowerType> flowerList = new List<FlowerType>();
    public List<Sprite> flowerHeadList = new List<Sprite>();
    public float pickupThreshold = 3.0f;
    public SpriteRenderer yesSprite;
    public SpriteRenderer noSprite;
    public SpriteRenderer flowerHeadSprite;
    public bool isWaitingForRegen = false;
    public float regenCooldown = 1.5f;
    public float timer = 0;
    public bool wasDeliveryWrong = false;
    public Transform[] availableDropPositions;
    public Transform deliveredFlower = null;

    private void Awake () {
        if (foxRequest == null) {
            foxRequest = this;
        }
    }

    // Use this for initialization
    void Start () {
        foreach (FlowerType f in flowerList) {
            Physics.IgnoreCollision(f.GetComponent<Collider>(), HorrorPlayerStats.horrorPlayerStats.GetComponent<Collider>());
        }
        currentRequest = null;
        regenCooldown = 1.5f;
        timer = 0;
        isWaitingForRegen = false;
        wasDeliveryWrong = false;
        GenerateNextRequest();
        //Call bubble
        ChangeFlowerHead();

    }
	
	// Update is called once per frame
	void Update () {
        if (isWaitingForRegen) {
            if (timer > 0) {
                timer -= Time.deltaTime;
            } else {
                timer = 0;
                if(!wasDeliveryWrong) {
                    GenerateNextRequest();
                    ChangeFlowerHead();
                } else {
                    noSprite.enabled = false;
                 }         
                isWaitingForRegen = false;
                wasDeliveryWrong = false;
            }
        }
	}

    public void GenerateNextRequest() {
        //TODO: Also check if its the last one (the player)
        yesSprite.enabled = false;
        noSprite.enabled = false;
        if (currentRequest != null) {
            flowerList.RemoveAt(0);
            if (flowerList.Count > 0) {                
                currentRequest = flowerList[0].flowerType;
            }  else {
                EndgameSceneManager.endgameManager.LoadEndGameScene(false);
            }          
        } else {
            currentRequest = flowerList[0].flowerType;
        }
        
    }

    public void DeliveryFeedback (bool correctDelivery) {
        if(correctDelivery) {
            print("Correct Delivery");
            yesSprite.enabled = true;
            isWaitingForRegen = true;
            timer = regenCooldown;
        } else {
            print("WRONG!");
            deliveredFlower.position = ChooseRandomDropPosition().position;
            deliveredFlower = null;
            noSprite.enabled = true;
            isWaitingForRegen = true;
            wasDeliveryWrong = true;
            timer = regenCooldown;
        }
    }

    public void ChangeFlowerHead() {
        if (currentRequest == "blue") {
            flowerHeadSprite.sprite = flowerHeadList[0];
        } else if (currentRequest == "orange") {
            flowerHeadSprite.sprite = flowerHeadList[1];
        } else if (currentRequest == "red") {
            flowerHeadSprite.sprite = flowerHeadList[2];
        } else if (currentRequest == "white") {
            flowerHeadSprite.sprite = flowerHeadList[3];
        }
    }

    Transform ChooseRandomDropPosition() {
        int randN = Random.Range(0, availableDropPositions.Length);
        Debug.Log(randN);
        return availableDropPositions[randN];
    }
}
