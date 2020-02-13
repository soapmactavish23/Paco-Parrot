using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg : MonoBehaviour {

	private float larguraTela;

	// Use this for initialization
	void Start () {
		//Fazer a imagem se mover
		GetComponent<Rigidbody2D> ().velocity = new Vector2(-3,0);

		//Definir o tamanho da imagem
		SpriteRenderer grafico = GetComponent<SpriteRenderer> ();

		//Receber o tamanho da imagem
		float larguraImagem = grafico.sprite.bounds.size.x;
		float alturaImagem = grafico.sprite.bounds.size.y;

		//Receber o tamanho da tela
		float alturaTela = Camera.main.orthographicSize*2;
		larguraTela = alturaTela / Screen.height * Screen.width;

		//Definir o tamanho da tela
		Vector2 novaEscala = transform.localScale;
		novaEscala.x = larguraTela / larguraImagem+0.25f;
		novaEscala.y = alturaTela / alturaImagem;
		transform.localScale = novaEscala;

		if(this.name == "imagemB"){
			transform.position = new Vector2 (larguraTela, 0);
		}

	}
	
	// Update is called once per frame
	void Update () {
		//Retornando o bg para o centro
		if(transform.position.x <= -larguraTela){
			transform.position = new Vector2 (larguraTela, 0);
		}
	}
}
