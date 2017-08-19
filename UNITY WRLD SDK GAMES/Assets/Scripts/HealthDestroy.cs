using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDestroy : MonoBehaviour {

	AudioSource audio;
	public Image damageImage;
	public Color flashColor = new Color (1f,0f,0f,0.3f);
	float flashSpeed = 5f;

	void Start()
	{
		audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("I am Injured.");
			GameOver.dead = true;		//tell GameOver to change color to show the GameOver text
			PlayerMovement.dead = true;		//tell player to stop moving and fall
			audio.Play ();		//play audio
			Destroy (gameObject, 10);	//destroy the plane after some time
			damageImage.color = flashColor;		//change the screen color to red
			//damageImage.color = Color.Lerp (flashColor,Color.clear,flashSpeed * Time.deltaTime);
		}
	}
}
