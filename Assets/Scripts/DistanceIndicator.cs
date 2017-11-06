using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceIndicator : MonoBehaviour {
	GameObject pin;
	GameObject wire;


	// Use this for initialization
	void Start () {
		pin = GameObject.FindGameObjectWithTag("Loop");
		wire = GameObject.FindGameObjectWithTag ("DistanceIndicator");
		wire.SetActive(true);
	}




	// Update is called once per frame
	void Update () {
		float distance; //Distance between the Pin and the virtual wire
		Vector4 posPin; //Position of the pin
		Vector4 posWire; //Position of the virtual wire
		posPin = pin.transform.position;
		posWire = wire.transform.position;
		distance = Vector4.Distance(posPin, posWire);
			//Vector3.Distance (posPin, posWire);
		Debug.Log ("Distance is " + distance);
	}
}
