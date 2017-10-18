using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionScript : MonoBehaviour {

	public Text collisionText;
	public Text youWinText;
	public Texture starFillTexture;
	private int healthcount;
	private int starsCount;
	private GameObject[] stars;



	// Use this for initialization
	void Start () {
		
		collisionText.text = "";
		youWinText.text = "";
		healthcount = 3;
		starsCount = 0;
		GameObject.FindGameObjectWithTag("Wire").SetActive(true);
		stars = GameObject.FindGameObjectsWithTag("Star");
		foreach (GameObject star in stars)
		{
			star.SetActive(true);
		}
	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Wire")) {

			collisionText.text = "Collision";
			Handheld.Vibrate ();
			healthcount--;
			switch(healthcount) {
			case 2  :
				GameObject.FindGameObjectWithTag("Health3").SetActive(false);
				break; /* optional */
			case 1 :
				GameObject.FindGameObjectWithTag("Health2").SetActive(false);
				break; /* optional */
			case 0:
				GameObject.FindGameObjectWithTag ("Health1").SetActive (false);
				collisionText.text = "";
				youWinText.text = "You Lose";
				break; /* optional */
			}
		}

		if (other.gameObject.CompareTag ("Star")) {

			starsCount++;

			switch(starsCount) {
			case 1  :
				GameObject.FindGameObjectWithTag("UiStar1").GetComponent<RawImage>().texture=(Texture) starFillTexture;
				break; /* optional */
			case 2 :
				GameObject.FindGameObjectWithTag("UiStar2").GetComponent<RawImage>().texture=(Texture) starFillTexture;
				break; /* optional */
			case 3 :
				GameObject.FindGameObjectWithTag("UiStar3").GetComponent<RawImage>().texture=(Texture) starFillTexture;
				break; /* optional */
			}

			Handheld.Vibrate ();
			other.gameObject.SetActive (false);
		}

		if (other.gameObject.CompareTag ("StartCube")) {

			collisionText.text = "Begin Game";
			Handheld.Vibrate ();
			other.gameObject.SetActive (false);


		}

		if (other.gameObject.CompareTag ("EndCube")) {
			
			other.gameObject.SetActive (false);
			youWinText.text = "You Win!";
			collisionText.text = "";
			Handheld.Vibrate ();


		}

	}


	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Wire")) {

			collisionText.text = "Going Great";

		}

	}
}
