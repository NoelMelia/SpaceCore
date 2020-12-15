using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerFlightControl : MonoBehaviour
{

	//"Objects", "For the main ship Game Object and weapons"));
	public GameObject actual_model; 
	//"Ship GameObject", "Point this to the Game Object that actually contains the mesh for the ship. Generally, this is the first child of the empty container object this controller is placed in."
	public Transform weapon_hardpoint_1;
	// Special Weapon to use
	public Transform weapon_hardpoint_2; 
	//"Weapon Hardpoint", "Transform for the barrel of the weapon"
	public GameObject bullet; 
	//Projectile GameObject", "Projectile that will be fired from the weapon hardpoint.
	public GameObject specialBullet;
	public bool activate = false;
	private bool gun;
	public float screen_clamp = 500; 
	//"Screen Clamp (Pixels)", "Once the pointer is more than this many pixels from the center, the input in that direction(s) will be treated as the maximum value."
	



	[HideInInspector]
	public float roll, yaw, pitch; 
	//Inputs for roll, yaw, and pitch, taken from Unity's input system.
	
	public bool afterburner_Active = false; 
	//True if afterburners are on.
	
	
	float distFromVertical; 
	//Distance in pixels from the vertical center of the screen.
	float distFromHorizontal; 
	//Distance in pixel from the horizontal center of the screen.

	Vector2 mousePos = new Vector2(0,0); 
	//Pointer position from CustomPointer
	
	float DZ = 0; 
	//Deadzone, taken from CustomPointer.
	
	public float timeLeft = 30.0f;
	float seconds;
	//---------------------------------------------------------------------------------
	
	void Start() {
		// Setting the screen for display
		mousePos = new Vector2(0,0);	
		DZ = CustomPointer.instance.deadzone_radius;
		gun = true;
	}
	
	void FixedUpdate () {
		if (actual_model == null) {
			Debug.LogError("(FlightControls) Ship GameObject is null.");
			return;
		}
		
		updateCursorPosition();
		
		if(activate)
		{// Setting the Special gun active or not for 30 seconds
			if(timeLeft > 0 ){
				gun = true;
				timeLeft -= Time.deltaTime;
				Debug.Log("time Left:" + timeLeft);
			}else{
				gun = false;
				timeLeft = 30f;// Resetting the time to 30
				activate = false;// Setting the guns off
			}
		}
	}			
	void updateCursorPosition() {// Following the arrow of mouse cursor
		mousePos = CustomPointer.pointerPosition;
		
		//Calculate distances from the center of the screen.
		float distV = Vector2.Distance(mousePos, new Vector2(mousePos.x, Screen.height / 2));
		float distH = Vector2.Distance(mousePos, new Vector2(Screen.width / 2, mousePos.y));
		
		//If the distances are less than the deadzone,
		//then we want it to default to 0 so that no movements will occur.
		if (Mathf.Abs(distV) < DZ)
			distV = 0;
		else 
			distV -= DZ; 
			//Subtracting the deadzone from the distance. 
			//If we didn't do this, there would be a snap as 
			//it tries to go to from 0 to the end of the deadzone.
			
		if (Mathf.Abs(distH) < DZ)
			distH = 0;	
		else 
			distH -= DZ;
			
		//Clamping distances to the screen bounds.	
		distFromVertical = Mathf.Clamp(distV, 0, (Screen.height));
		distFromHorizontal = Mathf.Clamp(distH,	0, (Screen.width));	
	
		//If the mouse position is to the left, then we want the distance 
		//to go negative so it'll move left.
		if (mousePos.x < Screen.width / 2 && distFromHorizontal != 0) {
			distFromHorizontal *= -1;
		}
		//If the mouse position is above the center, 
		//then we want the distance to go negative so it'll move upwards.
		if (mousePos.y >= Screen.height / 2 && distFromVertical != 0) {
			distFromVertical *= -1;
		}
	}
	void Update() {// Using the left and right mouse to fire the weapons
		if (Input.GetMouseButtonDown(0)) {
			fireShot();
		}
		if (Input.GetMouseButtonDown(1))
		{
			fireShot2();
		}
	}	
	public void fireShot() {// Left mouse click and only weapon at start on level
		if (weapon_hardpoint_1 == null) {
			Debug.LogError("(FlightControls) Trying to fire weapon, but no hardpoint set up!");
			return;
		}
		if (bullet == null) {
			Debug.LogError("(FlightControls) Bullet GameObject is null!");
			return;
		}
		
		//Shoots it in the direction that the pointer is pointing. 
		if (Camera.main == null) {
			Debug.LogError("(FlightControls) Main camera is null! Make sure the flight camera has the tag of MainCamera!");
			return;
		}
		
		GameObject shot1 = (GameObject) GameObject.Instantiate(bullet, weapon_hardpoint_1.position, Quaternion.identity);

		Ray vRay;

		if (!CustomPointer.instance.center_lock)
			vRay = Camera.main.ScreenPointToRay(CustomPointer.pointerPosition);
		else
			vRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));

		RaycastHit hit;
		
		//If we make contact with something in the world, 
		// we'll make the shot actually go to that point.
		if (Physics.Raycast(vRay, out hit)) {
			shot1.transform.LookAt(hit.point);
			shot1.GetComponent<Rigidbody>().AddForce((shot1.transform.forward) * 9000f);
			
		
		//Otherwise, since the ray didn't hit anything, we're just going to guess and shoot the projectile in the general direction.
		} else {
			shot1.GetComponent<Rigidbody>().AddForce((vRay.direction) * 9000f);	
		}
	}
	public void fireShot2()// Right Mouse Click when activated
	{// Same as above gun fire shot
		if (weapon_hardpoint_2 == null)
		{
			Debug.LogError("(FlightControls) Trying to fire weapon, but no hardpoint set up!");
			return;
		}

		if (specialBullet == null)
		{
			Debug.LogError("(FlightControls) Bullet GameObject is null!");
			return;
		}

		//Shoots it in the direction that the pointer is pointing. Might want to take note of this line for when you upgrade the shooting system.
		if (Camera.main == null)
		{
			Debug.LogError("(FlightControls) Main camera is null! Make sure the flight camera has the tag of MainCamera!");
			return;
		}
		if(activate && gun){// Checking to see if put conditions are meet to activate
			GameObject shot2 = (GameObject)GameObject.Instantiate(specialBullet, weapon_hardpoint_2.position, Quaternion.identity);

			Ray vRay;

			if (!CustomPointer.instance.center_lock)
				vRay = Camera.main.ScreenPointToRay(CustomPointer.pointerPosition);
			else
				vRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));

			RaycastHit hit;
			if (Physics.Raycast(vRay, out hit))
			{
				shot2.transform.LookAt(hit.point);
				shot2.GetComponent<Rigidbody>().AddForce((shot2.transform.forward) * 9000f);


				//Otherwise, since the ray didn't hit anything, 
				// we're just going to guess and shoot the projectile in the general direction.
			}
			else
			{
				shot2.GetComponent<Rigidbody>().AddForce((vRay.direction) * 9000f);
			}
		}
	}
}