using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour 
{
	float movementSpeed =30;
	float mouseSens = 2f;
	float rotYRange = 60.0f;
	float verticalRotation = 0f;
	float verticalVelocity = 0f;
	CharacterController cc;
	
	// Use this for initialization
	void Start () 
	{
		Screen.lockCursor = true;
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{	
		//Rotation
		float rotX = Input.GetAxis ("Mouse X")*mouseSens;
		transform.Rotate (0, rotX, 0);
		
		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSens;
		verticalRotation = Mathf.Clamp (verticalRotation, -rotYRange, rotYRange);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);
		
		//Movement
		float forwardSpeed = Input.GetAxis ("Vertical")*movementSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal")*movementSpeed;
		
		//Gravity
		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		
		if (Input.GetButtonDown ("Jump") && cc.isGrounded) 
		{
			verticalVelocity = 10f;
		}
		
		
		
		Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed);
		speed = transform.rotation * speed;
		cc.Move	 (speed*Time.deltaTime);
	}
}
