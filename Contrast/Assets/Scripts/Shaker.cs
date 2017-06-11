using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour {

	public float intensity = 1.0f;
	public Vector3 moveAmount;
	public Vector3 moveSpeed;

	public Vector3 rotAmount;
	public Vector3 rotSpeed;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.localPosition = new Vector3 ( (Mathf.Sin(Time.time*moveSpeed.x))* moveAmount.x, (Mathf.Sin(Time.time*moveSpeed.y))* moveAmount.y, (Mathf.Sin(Time.time*moveSpeed.z))* moveAmount.z)*intensity;
		transform.localEulerAngles = new Vector3 ( (Mathf.Sin(Time.time*rotSpeed.x))* rotAmount.x, (Mathf.Sin(Time.time*rotSpeed.y))* rotAmount.y, (Mathf.Sin(Time.time*rotSpeed.z))* rotAmount.z)*intensity;
		
	}
}
