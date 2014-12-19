using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	private GameControl control;
	private bool wonGame; //Keeps track if crossed the line.
	private int check;

	// Use this for initialization
	void Start () 
	{
		//Find gameobject Control and attach it.
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			control = gameControllerObject.GetComponent <GameControl>();
		}
		if (control == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		wonGame = false;
		check = 0;
	}

	void Update()
	{
	}
	
	// Update is called once per frame for Physics
	void FixedUpdate () {
		if (!wonGame) 
		{
			//Only get input on the horizon.
			float movementHorizontal = Input.GetAxis ("Horizontal");
			Vector3 movement = new Vector3 (movementHorizontal, 0.0f, 0.0f);
			rigidbody.AddForce (movement * 20);
			//Jump the cubev when space is pressed
			if (Input.GetKeyDown (KeyCode.UpArrow))
			{
				Debug.Log ("JUMP");
				rigidbody.velocity = new Vector3(movementHorizontal, 5, 0);
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		//If the player collides with an object and that object is the finish line call the game manager functiion you win
		if (other.gameObject.tag == "Finish") 
		{
			control.toggleFinishText ();
			wonGame = true;
			rigidbody.velocity = new Vector3 (0, 0, 0);
		}
		else if (other.gameObject.tag == "Checkpoint")
		{
			check++;
			control.setText("Check Point " + check);
			Destroy(other); //Get rid of the checkpoint to prevent from going back to previous ones.
			//transform.Translate(-10, 0, 0);
		}
	}
	public Vector3 getPosition()
	{
		return transform.position;
	}
}
