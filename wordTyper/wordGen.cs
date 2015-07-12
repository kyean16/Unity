using UnityEngine;
using System.Collections;

public class wordGen {

	//Collections of words"
    
	private static string getSubject(){
		string[] subject = new string[]{"I","You","He","She","It","They"};
		int placement = Random.Range (0, subject.Length);
	    return subject[placement];
	}

	private static string getVerb(){
		string[] verb = new string[]{"ran","jump","sit","dance","sleep","eat"};
		int placement = Random.Range (0, verb.Length);
		return verb [placement];
	}

	public static Word newWord( ) {

		string wordText = getSubject() + " " + getVerb();

		Word word1 = new Word(wordText, 6);
		return word1;
		
	}
	
}

public class Word{
	public string Name { get; set; }
	public int Score { get; set; }
	public Word(string name, int score)
	{
		Name = name;
		Score = score;
	}
}