using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {
	//Variaveis
	bool init;
	bool finished;
	int pontos;

	//Componente
	Rigidbody2D playerBody;

	//Forca do impulso
	Vector2 force = new Vector2(0, 500f);

	//Particle
	public GameObject particle;

	//Textos
	public Text txtTitle;
	public Text txtTitleSombra;
	public Text txtInit;

	// Use this for initialization
	void Start () {
		pontos = 0;
		playerBody = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (!finished) {
			//Quando pressionar no botao do mouse
			if (Input.GetButtonDown ("Fire1")) {
				if (!init) {
					init = true;
					playerBody.isKinematic = false;

					//Mudar os textos
					txtInit.text = "";
				}

				//Zerar a velocidade
				playerBody.velocity = new Vector2 (0,0);

				//Adicionar o impulso
				playerBody.AddForce(force);

				//Mais pontos
				pontos++;
				txtTitle.text = "Score:" + pontos.ToString();
				txtTitleSombra.text = "Score:" + pontos.ToString();

				//Instanciar a particula
				GameObject pena = Instantiate(particle);
				pena.transform.position = this.transform.position;
			}

			//Vendo a Altura do player em pixels
			float alturaPlayerPixels = Camera.main.WorldToScreenPoint (transform.position).y;

			if(alturaPlayerPixels > Screen.height || alturaPlayerPixels < 0){
				GameOver ();
			}

			transform.rotation = Quaternion.Euler (0,0,playerBody.velocity.y*2);
		}
	}

	void OnTriggerEnter2D(Collider2D outro){
		if (init) {
			if (!finished) {
				GameOver ();
			}
		}
	}

	void GameOver(){
		finished = true;
		GetComponent<Collider2D> ().enabled = false;
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-300, 0));
		GetComponent<Rigidbody2D> ().AddTorque (300f);
		GetComponent<SpriteRenderer> ().color = new Color (1.0f, 0.35f, 0.35f);
		Invoke ("reset", 1.5f);
	}

	void reset(){
		Application.LoadLevel (0);
	}
}
