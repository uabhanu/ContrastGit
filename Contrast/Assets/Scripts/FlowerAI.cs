using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAI : MonoBehaviour {

	private Vector3 wishDir;
	private float bestDistance;
	private bool checkingSelf;
	public float checkDeviate = 0.4f;
	private Vector3 newDir;
	private Rigidbody myBod;
	public float moveForce = 20.0f;
	public float maxSpeed = 3.0f;
	public float avoidance = 1.0f;

	// Use this for initialization
	void Start () {

		myBod = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per physics frame
	void FixedUpdate () {



		RaycastHit hit;


		myBod.velocity = Vector3.ClampMagnitude (myBod.velocity, maxSpeed);


		//not checking myself? check myself!

		if (!checkingSelf && wishDir.magnitude > 0.0f) {

			checkingSelf = true;
			if (Physics.Raycast (transform.position, wishDir, out hit, 500.0f))
				bestDistance = hit.distance;
			else
				bestDistance = 500.0f;


		} else {
			checkingSelf = false;

			//check a new direction, if better than wish set as new wish

			float velocityBias = (1 - (myBod.velocity.magnitude / maxSpeed)) * 3 + 0.2f;

			newDir = Vector3.Normalize(wishDir + (Vector3.Normalize(new Vector3(Random.Range(-1.0f,1.0f),0,Random.Range(-1.0f,1.0f))) * checkDeviate * velocityBias));

			if (Physics.Raycast (transform.position, newDir, out hit, 500.0f)) {

				Debug.DrawLine(transform.position,  hit.point, Color.green, 0.1f, false);


				if (hit.distance >= bestDistance) {
					bestDistance = hit.distance;
					wishDir = newDir;
				}
			
			} else {
				bestDistance = 500.0f;
				wishDir = newDir;
			}



		}

		//add torque to face?

		//move 

		if (bestDistance <= avoidance)
			myBod.AddForce (wishDir * moveForce *-1);
			else
		myBod.AddForce (wishDir * moveForce);


	}
}
