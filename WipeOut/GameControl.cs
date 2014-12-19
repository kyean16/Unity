using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public GameObject player; //Prefab
	public GUIText finishText;
	public Vector3 location;
	private CameraControl mainCamera;

	// Use this for initialization
	void Start () {
		finishText.text = ""; //Empty
		
		location = new Vector3(0.0f,0.0f,0.0f);
		//Instantiate(player,location,spawnRotation);
		
	    GameObject cam = GameObject.FindWithTag ("MainCamera");
		mainCamera = cam.GetComponent <CameraControl>();
		
	}
	
	// Update is called once per frame
	void Update () {
		//If the user is below 7 unit on the Y axis restart level
		if (player.transform.position.y < -7)
		{
			Debug.Log(player.rigidbody.velocity);
			player.transform.position = location;
			player.rigidbody.velocity = new Vector3(0.0f,0.0f,0.0f);
			Debug.Log(player.rigidbody.velocity);
			//stop movement;
			//player.transform.Translate(0, 10, 0, Space.World);
			//Destroy(player);
			//mainCamera.setCamera();
			
			//Application.LoadLevel (Application.loadedLevel);
		}
		//If the user pushes the key 'R' restart the level
		if (Input.GetKeyDown (KeyCode.R))
		{
			Debug.Log(player.rigidbody.velocity);
			player.transform.position = location;
			player.rigidbody.velocity = new Vector3(0.0f,0.0f,0.0f);
			Debug.Log(player.rigidbody.velocity);
			//Stop movement;
			//Destroy(player);
			//Quaternion spawnRotation = new Quaternion ();
			//Instantiate(player,location,spawnRotation);
			//mainCamera.setFocus(player);
			//Application.LoadLevel (Application.loadedLevel);
			//mainCamera.setCamera();
		}
	}

	//Crosses the finish line/.
	public void toggleFinishText()
	{
		finishText.text = "You Win!";
	}

	//Change text at will
	public void setText(string temp)
	{
		finishText.text = temp;
		//Memorize the location of the player at current use for respawn.
		Debug.Log(player.transform.position);
		location = player.transform.position; //Set new Spawn Point.
	}
}
