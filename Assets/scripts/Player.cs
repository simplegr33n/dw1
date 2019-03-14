using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public int playerSpeed = 10;
	public bool facingRight = true;
	public int playerJumpPower = 1250;
	public float moveX;

	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -10) {
			die();
		}
		Move();
	}


	void Move() {
		// CONTROLS
		moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump")) {
			Jump();
		}
		// ANIMATIONS
		// PLAYER DIRECTION
		if (moveX > 0.0f && !facingRight) {
			HorizontalFlip();
		} else if (moveX < 0.0f && facingRight) {
			HorizontalFlip();
		}
		// PHYSICS
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

	}

	void Jump() {
		//JUMPING CODE
		GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
	}

	void HorizontalFlip() {
		//FLIP PLAYER CODE
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void die() {
		SceneManager.LoadScene("Prototype_1");
	}
}
