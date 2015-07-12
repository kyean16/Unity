using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	public Text timera;

	public float myTimer = 2.0f;
	public bool start = false;


	// Update is called once per frame
	void FixedUpdate () {
		if (start) {
			if (myTimer > 0.0f) {
				myTimer -= Time.deltaTime;
				if(myTimer <= 0.0f){
					myTimer = 0.0f;
				}
				timera.text = myTimer.ToString ().Remove (myTimer.ToString ().Length - 4);
			} else {
				start = false;
				timera.text = "0.0";
			}
		}
	}

	//Start timer when button is clicked
	public void startTimer(){
		start = true;
		myTimer = 10.0f;
	}
}
