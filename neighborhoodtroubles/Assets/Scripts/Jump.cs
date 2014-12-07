using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	public float jumpHeight;
	public float multiplier;
	public bool canJump = true;
	public AudioClip jumpsound;
	public AudioClip powerup;

	void OnTriggerEnter2D(Collider2D col)
	{ if (col.gameObject.tag == "burger") 
		{ Destroy (col.gameObject); 
		  gameObject.audio.PlayOneShot (powerup);
		} 
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "ground") {
			Debug.Log ("colliders are colliding");
			canJump = true;		
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && canJump) {
			rigidbody2D.AddForce (Vector2.up * jumpHeight);

			//jump sound
			gameObject.audio.PlayOneShot (jumpsound);
			canJump = false;
		}
	}
}
