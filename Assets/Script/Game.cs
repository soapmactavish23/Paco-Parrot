using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public GameObject inimigo;
	public Button btnSair;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CriaInimigo", 1.0f, 2.0f);
		btnSair.onClick.AddListener (Sair);
	}

	void Sair(){
		Application.Quit ();
	}

	void CriaInimigo(){

		float alturaAleatoria = 10.0f * Random.value - 5;

		GameObject novoInimigo = Instantiate (inimigo);
		novoInimigo.transform.position = new Vector2 (15.0f, alturaAleatoria);

	}
}
