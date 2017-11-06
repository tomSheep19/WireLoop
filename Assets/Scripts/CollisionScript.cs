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
	private Color distanceIndicator;


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
		/*
		if (other.gameObject.CompareTag ("IndicatorGreen")) {
			collisionText.text = "Too Close";
			GameObject current = GameObject.FindGameObjectWithTag ("Loop");
			Material curMaterial = Resources.Load("Shade_Loop_Green", typeof(Material)) as Material;
			current.GetComponent<MeshRenderer>().material = curMaterial;

		}*/

		if (other.gameObject.CompareTag ("IndicatorYellow")) {
			collisionText.text = "Too Close";
			GameObject current = GameObject.FindGameObjectWithTag ("Loop");
			Material curMaterial = Resources.Load("Shade_Loop_Orange", typeof(Material)) as Material;
			current.GetComponent<MeshRenderer>().material = curMaterial;

		}

		if (other.gameObject.CompareTag ("IndicatorRed")) {
			collisionText.text = "A Lit Bit Close !";
			GameObject current = GameObject.FindGameObjectWithTag ("Loop");
			Material curMaterial = Resources.Load("Shade_Loop_Red", typeof(Material)) as Material;
			current.GetComponent<MeshRenderer>().material = curMaterial;
		}

		//When Moving up, the color should be red -> orange -> normal
		if (other.gameObject.CompareTag ("IndicatorYellow")) {
			collisionText.text = "Too Close !";
			GameObject current = GameObject.FindGameObjectWithTag ("Loop");
			Material curMaterial = Resources.Load("Shade_Loop_Orange", typeof(Material)) as Material;
			current.GetComponent<MeshRenderer>().material = curMaterial;

		}
			

	}

	/*
	Material material = new Material(Shader.Find("Transparent/Diffuse"));
	material.color = Color.green;
	//material.SetVector("_Color",new Vector4(1,1,1,1));
	GetComponent<Renderer>().material = material;
	*/
	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Wire")) {

			collisionText.text = "Going Great";

		}


		if (other.gameObject.CompareTag ("IndicatorRed") || other.gameObject.CompareTag ("IndicatorYellow")) {
			collisionText.text = "Going Great";
			GameObject current = GameObject.FindGameObjectWithTag ("Loop");
			Material curMaterial = Resources.Load("Shade_Original", typeof(Material)) as Material;
			current.GetComponent<MeshRenderer> ().material = curMaterial;

			//distanceIndicator =  new Color(182, 153, 127, 255);
			//current.GetComponent<MeshRenderer> ().material.color = distanceIndicator;

		}


	}
}
