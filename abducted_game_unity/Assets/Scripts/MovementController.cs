using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	public float walkSpeed;
	public float jumpSpeed;
	public float crouchSpeed;
	public float runSpeed;
	public float gravity;

	private bool crouched = false;

	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);

			if (Input.GetKey(KeyCode.LeftShift)) {
				moveDirection *= runSpeed;
			} else if (crouched) {
				moveDirection *= crouchSpeed;
			} else {
				moveDirection *= walkSpeed;
			}
			
			if (Input.GetButton("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		}

		if (Input.GetKeyDown(KeyCode.LeftControl)) {
			crouched = !crouched;
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
