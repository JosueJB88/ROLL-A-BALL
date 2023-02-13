using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JugadorController : MonoBehaviour
{
	private Rigidbody rb;
	
	
	public float velocidad;
	
	private int contador;
	
	public TextMeshProUGUI textoContador, textoGanar;
	
	public AudioSource audio;
	
	public GameObject  boton;

	
	void Start () {
		//Capturo esa variable al iniciar el juego
		rb = GetComponent<Rigidbody>();
		
		contador = 0;
		
		setTextoContador();
		
		
			textoGanar.text = "";
	}
	
	
	void Update(){
		float movimientoH = Input.GetAxis("Horizontal");
		float movimientoV = Input.GetAxis("Vertical");
		
		
		Vector3 movimiento = new Vector3(movimientoH, 0.0f,movimientoV);
		
		rb.AddForce(movimiento * velocidad);



	}
	
	
	
	// Para que se sincronice con los frames de física del motor
	void FixedUpdate () {
		
		float movimientoH = Input.GetAxis("Horizontal");
		float movimientoV = Input.GetAxis("Vertical");
		
		Vector3 movimiento = new Vector3(movimientoH, 0.0f,
			movimientoV);
		
		rb.AddForce(movimiento);
	}
	
	void OnTriggerEnter(Collider other)
 {
	 if (other.gameObject.CompareTag ("Coleccionables"))
	 {
		 other.gameObject.SetActive (false);
		 
		 audio.Play();
		 
		 contador = contador + 1;
		 
		 
		 setTextoContador();
	 }
 
 }
 
 void setTextoContador(){
	  textoContador.text = "Contador: " + contador.ToString();
	 if (contador >= 12){
		 textoGanar.text = "¡Ganaste!";
		 
		 boton.gameObject.SetActive (true);
		 
	 }
	 
 }
}


