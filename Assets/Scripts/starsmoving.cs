using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starsmoving : MonoBehaviour {

	public int step = 1;
	public int radius = 30;
	public float x0 = 0;
	public int dirc = 0;

	// Use this for initialization
	void Start () {
		x0 = transform.position.x;
		dirc = 0;
	}

	// Update is called once per frame
	void Update () {
		if (dirc % (4 * radius) / radius == 0 || dirc % (4 * radius) / radius == 3) {
			transform.Translate (step, 0, 0); 
		} else {
			transform.Translate (-step, 0, 0); 
		}
		dirc += step;
	}

}
