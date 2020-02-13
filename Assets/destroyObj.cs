using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("apagaObjeto", 1.5f);
	}
	
	// Update is called once per frame
	void apagaObjeto () {
		Destroy (gameObject);
	}
}
