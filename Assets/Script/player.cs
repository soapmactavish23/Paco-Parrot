using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	//Variaveis
	bool init;
	bool finished;

	//Componente
	Rigidbody2D playerBody;

	//Forca do impulso
	Vector2 force = new Vector2(0, 500f);

	//Particle
	public GameObject particle;

	// Use this for initialization
	void Start () {

		playerBody = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		//Quando pressionar no botao do mouse
		if (Input.GetButtonDown ("Fire1")) {
			if (!init) {
				init = true;
				playerBody.isKinematic = false;
			}

			//Zerar a velocidade
			playerBody.velocity = new Vector2 (0,0);

			//Adicionar o impulso
			playerBody.AddForce(force);


			//Instanciar a particula
			GameObject pena = Instantiate(particle);
			pena.transform.position = this.transform.position;
		}

		//Vendo a Altura do player em pixels
		float alturaPlayerPixels = Camera.main.WorldToScreenPoint (transform.position).y;

		if(alturaPlayerPixels > Screen.height || alturaPlayerPixels < 0){
			Destroy (gameObject);
			//Application.LoadLevel (0);
		}

		transform.rotation = Quaternion.Euler (0,0,playerBody.velocity.y*2);
	}
}
