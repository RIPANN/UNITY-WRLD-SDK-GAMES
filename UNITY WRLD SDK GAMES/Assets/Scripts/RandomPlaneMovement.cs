using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPlaneMovement : MonoBehaviour {

	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();

	}

	// Update is called once per frame
	void Update () {

		//initially the agent.pathPending will be zero so we set a newDestination for it

		if(!agent.pathPending)	//i.e if the agent has reached destination then re navigate to new position
		{

			//again we check if the remaining distance and the stoping distance has been reached
			//remaining distance - > current distance between agent and destiantion
			//stopping distance -> at what distance the agent stopped near destination

			if (agent.remainingDistance <= agent.stoppingDistance) {

				//Then check again if the agent has more path to cover or the agent has reached destination and stooped there(velocity)

				if(!agent.hasPath || agent.velocity.sqrMagnitude == 0f){

					//finally set a NewDestination() for the plane
					SetNewDestination();
				}
			}
		}
	}

	void SetNewDestination(){
		Vector3 newDest = Random.insideUnitSphere * 500f ;
		//+ new Vector3 (308f, 183f, -472f)

		NavMeshHit hit;
		bool hasPosition = NavMesh.SamplePosition (newDest, out hit, 200f, 1);
		if (hasPosition) {
			agent.SetDestination (hit.position);
		}
	}
}
