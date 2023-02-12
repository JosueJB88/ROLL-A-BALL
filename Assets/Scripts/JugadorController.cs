using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorController : MonoBehaviour
{
	private Rigidbody rb;
	
	
	public float velocidad;
	
	private int contador;

	
	void Start () {
		//Capturo esa variable al iniciar el juego
		rb = GetComponent<Rigidbody>();
		
		contador = 0;
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
		 
		 contador = contador + 1;
	 }
 }

	
}


