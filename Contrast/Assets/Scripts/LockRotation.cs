using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour {
    private Quaternion q_OriginalRotation;

	// Use this for initialization
	void Start () {
        q_OriginalRotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = q_OriginalRotation;
	}

    private void FixedUpdate () {
       this.transform.rotation = q_OriginalRotation;
    }
}
