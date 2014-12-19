using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	private Vector3 offset;
	private GameObject player;

	
	// Use this for initialization
	void Start () {
		offset = transform.position;
		setCamera();

	}
	
	//Public function to set the camera to an object named player;
	public void setCamera()
	{
		player = GameObject.FindWithTag ("Player");
	}
	
	public void setFocus(GameObject temp)
	{
		player = temp;
	}
	

	//Follow the characters	
	void LateUpdate(){
		if(player != null)
		{
			transform.position = player.transform.position + offset;
		}
	}
	
}
