using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour {

	public Text wordText,scoreText; //Text Windows
	public timer testTimer; 
	public Button buttonTest; //Button
	public InputField inputTest; //Input
	public bool gamePlay;

	//Game Settings?
	private int score = 0; //Score of the game
	private Word word;

	/**
	 * Updates Time and check.
	 */
	void Update(){
		if (testTimer.myTimer == 0.0f && gamePlay) {
			wordText.text = "Game Over.";
			buttonTest.interactable = true;
			inputTest.interactable = false;
			inputTest.text ="";
			inputTest.DeactivateInputField();
		}
	}

	/*
	 * Function that starts the game.
	 * */
	public void setStartGame(){;
		word = wordGen.newWord(); //New Word
		wordText.text = word.Name; //Set Name
		buttonTest.interactable = false;
		inputTest.interactable = true;
		inputTest.Select();
		inputTest.ActivateInputField ();
		gamePlay = true;
		testTimer.startTimer ();
		score = 0;
		scoreText.text = "Score: " + score;
    }

	/**
	 * Compare Match
	 * */
	public void getMatch(){
		if (inputTest.text.ToString () == wordText.text.ToString().ToLower() || inputTest.text.ToString () == wordText.text.ToString() ) {
			gamePlay = false;
			setWord();
		}
	}

	/**
	 * Set the new word and update score by 1.
	 * */
	public void setWord(){
		inputTest.text ="";//Resets Text
		score += word.Score;//word.Score; //Increase score by 1
		scoreText.text = "Score: " + score;
		word = wordGen.newWord(); //New Word
		wordText.text = word.Name; //Set Name
		testTimer.startTimer ();
	}


	public void win(){
		wordText.text = "You Win";
		buttonTest.interactable = true;
		inputTest.interactable = false;
		inputTest.text ="";
		inputTest.DeactivateInputField();
		testTimer.myTimer = 0.0f;
	}

}
