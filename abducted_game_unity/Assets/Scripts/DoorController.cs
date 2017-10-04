using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	public GameObject wall;
	private Vector3 wallPos;
	private bool doorOpen = false;
	private GameObject gos;

	// Use this for initialization
	void Start () {
		wallPos = wall.transform.position;
		gos = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		detectClosePlayer();
	}

	void detectClosePlayer() {
		Vector3 position = transform.position;
		//Vector3 diff = (gos.transform.position - position);
		Vector3 gosPos = gos.transform.position;
		float diffz = Mathf.Abs(position.z - gosPos.z);
		float diffx = Mathf.Abs(position.x - gosPos.x);

		if (diffz < 2f && diffx < 2f) {
			//doorOpen = true;
			openDoor();
		} else if (diffz > 2f || diffx > 2f) {
			closeDoor();
			if (doorOpen) {
				//do something
			}
		}
	}

	void openDoor() {
		if (wall.transform.position.z >= (wallPos.z - 4)) {
			wall.transform.position = new Vector3(
				wallPos.x,
				wallPos.y,
				wall.transform.position.z - 0.1f
			);
		}
	}

	void closeDoor() {
		if (wall.transform.position.z < (wallPos.z)) {
			wall.transform.position = new Vector3(
				wallPos.x,
				wallPos.y,
				wall.transform.position.z + 0.1f
			);
		}
	}


	GameObject findClosestPlayer() {
		GameObject gos = GameObject.FindGameObjectWithTag("Player");
		GameObject closest;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;

		Vector3 diff = (gos.transform.position - position);
		float curDistance = diff.sqrMagnitude;

		if (curDistance < distance) {
			closest = gos;
			distance = curDistance;
		} else {
			closest = null;
		}

		return closest;
	}
}
