using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionScript : MonoBehaviour {

	public Text scoreText;
	public Text starText;
	private int count;
	private int starsCount;
	private GameObject[] stars;

	// Use this for initialization
	void Start () {
		// scoreText.text = "No collision";
		scoreText.text = "Start from the Start point!";
		//healthText.text = "Heart * Three";
		starText.text = "Stars : 0";
		count = 3;
		starsCount = 0;
		GameObject.FindGameObjectWithTag("Wire").SetActive(true);
		GameObject.FindGameObjectWithTag("Health1").SetActive(true);
		GameObject.FindGameObjectWithTag("Health2").SetActive(true);
		GameObject.FindGameObjectWithTag("Health3").SetActive(true);
		stars = GameObject.FindGameObjectsWithTag("Star");
		foreach (GameObject star in stars)
		{
			star.SetActive(true);
		}
	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Wire")) {

			scoreText.text = "Collision Detected";
			Handheld.Vibrate ();
			count--;
			switch(count) {
			case 2  :
				GameObject.FindGameObjectWithTag("Health3").SetActive(false);
				break; /* optional */
			case 1 :
				GameObject.FindGameObjectWithTag("Health2").SetActive(false);
				break; /* optional */
			case 0 :
				scoreText.text = "Game over";
				GameObject.FindGameObjectWithTag("Wire").SetActive(false);
				stars = GameObject.FindGameObjectsWithTag("Star");
				foreach (GameObject star in stars)
				{
					star.SetActive(false);
				}
				GameObject.FindGameObjectWithTag("Health1").SetActive(false);
				break; /* optional */
			}
		}

		if (other.gameObject.CompareTag ("Star")) {
			starsCount++;
			starText.text = "Stars : " + starsCount;
			other.gameObject.SetActive (false);
		}

		if (other.gameObject.CompareTag ("StartCube")) {

			scoreText.text = "The Game was Started!";
			Handheld.Vibrate ();


		}

		if (other.gameObject.CompareTag ("EndCube")) {

			scoreText.text = "Good Job!";
			Handheld.Vibrate ();


		}

	}


	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Wire")) {

			scoreText.text = "No collision";

		}

	}
}
