using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHandlerScript : MonoBehaviour {

    public static DisplayHandlerScript displayHandlerScript;

    void Awake () {
        DontDestroyOnLoad(transform.gameObject);
        if (displayHandlerScript == null) {
            displayHandlerScript = this;
        } else if(displayHandlerScript != this) {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
