using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour {
    private Quaternion _OriginalRotation;

	// Use this for initialization
	void Start () {
        _OriginalRotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
       // this.transform.rotation = _OriginalRotation;
	}

    private void FixedUpdate () {
        this.transform.rotation = _OriginalRotation;
    }
}
