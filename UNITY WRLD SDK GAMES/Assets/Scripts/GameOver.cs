using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public static bool dead = false;
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		text.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (dead) {
			text.text = "Game Over";	//if player is dead then show game over text
		}
	}
}
