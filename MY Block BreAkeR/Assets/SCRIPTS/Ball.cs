using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour {
 private Paddle paddle;
 private bool hasStarted = false;
 public AudioSource audio;
 
 private Vector3 paddleToBallVector;
 private Rigidbody2D rb;
 // Use this for initialization
 void Start () {

    
 paddle = GameObject.FindObjectOfType<Paddle>();
 rb = GetComponent<Rigidbody2D>();
 paddleToBallVector = this.transform.position - paddle.transform.position;


 //hasStarted = true;
 }
 
 // Update is called once per frame
 void Update ()
	{
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
 
			if (Input.GetMouseButtonDown (0)) {
				print ("MouseButtonClicked");
				hasStarted = true;
 
				rb.velocity = new Vector2 (2f, 10f);
			}
		}



	}
	void onCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range(0f,0.2f), Random.Range(0f, 0.2f));

		rb.velocity += tweak; 

			GetComponent<AudioSource>().Play();
			Debug.Log ("SFX");


	}
}