﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Donk : MonoBehaviour
{

    public int playerSpeed = 10;
    public bool facingRight = true;
    public int playerJumpPower = 1250;
    public float moveX;
	public bool isGrounded;


    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -10)
        {
            Die();
        }
        Move();
		Raycast();
    }


    void Move()
    {
        // CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        // ANIMATIONS
        // PLAYER DIRECTION
        if (moveX > 0.0f && !facingRight)
        {
            HorizontalFlip();
        }
        else if (moveX < 0.0f && facingRight)
        {
            HorizontalFlip();
        }
        // PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void Jump()
    {
		if (!isGrounded) {
			return;
		}
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
		isGrounded = false;
		Debug.Log("jumping, isGrounded " + isGrounded);
    }

    void HorizontalFlip()
    {
        //FLIP PLAYER CODE
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Die()
    {
        SceneManager.LoadScene("Prototype_1");
    }

	void OnCollisionEnter2D(Collision2D col) {
		Debug.Log("Donk has collided with: " + col.collider.name);
		if (col.gameObject.tag == "Solid Block") {
			isGrounded = true;
		}	
	}

    void Raycast()
    {
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        // if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag == "Enemy")
        // {
        //     GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
        // }

        // if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag != "Enemy")
        // {
        //     isGrounded = true;
        // }
    }
}
