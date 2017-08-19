using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6.0f;
	public static bool dead = false;		//to check the player life status
	Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();	//acess the plauyer rigid body
	}

	// Update is called once per frame
	void Update () {
		if (!dead) {
			Move ();		//move until th eplayer is alive
		} else if (dead) {
			Debug.Log ("Going Down");
			rb.useGravity = true;	//player dead so start falling
		}
	}

	void Move(){
		transform.position += Camera.main.transform.forward.normalized * speed * Time.deltaTime;
		//in the above line we move the object in the direction of camera facing
		//forward.xy,z ranges from 0-1 where if an object faces one axis the transform.forward of that
		//corresponding axis would be 1 and evry other axis would be 0.
		//we take the forward vector and noramlize it to make its agnitude 1
		//then multiply with speed and Time.deltaTime(for smoothing by frame)
	}


}
