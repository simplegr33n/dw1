using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadBad : MonoBehaviour {

	public int EnemySpeed = 2;
	public float XMoveDirection = -1;

	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (XMoveDirection, 0) * EnemySpeed;
        if (hit.distance < 0.7f) {
            HorizontalFlip();
        }
	}

    void HorizontalFlip() {
        Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;

        if (XMoveDirection > 0) {
            XMoveDirection = -1;
        } else {
            XMoveDirection = 1;    
        }
    }

	void Die() {

	}
}