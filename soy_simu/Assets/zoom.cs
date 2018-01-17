using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x-1,gameObject.transform.position.y-1,gameObject.transform.position.z-1);
		}
		if (Input.GetMouseButtonDown (1)) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x+1,gameObject.transform.position.y+1,gameObject.transform.position.z+1);
		}
	}
}
