using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {

	float larguraTela;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2(-4,0);

		//Receber o tamanho da tela
		float alturaTela = Camera.main.orthographicSize*2;
		larguraTela = alturaTela / Screen.height * Screen.width;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < -larguraTela/2) {
			Destroy (gameObject);
		}
	}
}
