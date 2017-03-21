using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private int count;
	public Text countText;
	public Text winText;
	private Rigidbody2D rb2d;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		winText.text = "";
		SetCountText ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float movevertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, movevertical);
		rb2d.AddForce (movement*speed);
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
			}
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count>=4)
		{winText.text = "you win!";}
	}
}
