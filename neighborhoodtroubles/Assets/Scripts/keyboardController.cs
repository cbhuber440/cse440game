using UnityEngine;
using System.Collections;
public class keyboardController : MonoBehaviour {
	public float moveSpeed;
	bool facingRight = true;
	public void SetColliderForSprite( int spriteNum )
	{
		colliders[currentColliderIndex].enabled = false;
		currentColliderIndex = spriteNum;
		colliders[currentColliderIndex].enabled = true;
	}
	private Vector3 moveDirection;
	[SerializeField]
	private PolygonCollider2D[] colliders;
	private int currentColliderIndex = 0;
	private bool isInvincible = false;
	private float timeSpentInvincible;
	private int lives = 3;

	void Start ()
	{
	}
	void Update () {
		movement ();
		if (isInvincible)
		{
			timeSpentInvincible += Time.deltaTime;
			if (timeSpentInvincible < 3f) {
				float remainder = timeSpentInvincible % .3f;
				renderer.enabled = remainder > .15f; 
			}
			else {
				renderer.enabled = true;
				isInvincible = false;
			}
		}
	}

	void movement()
	{
		if (Input.GetKey (KeyCode.A))
		{
			transform.Translate(new Vector3(-moveSpeed, 0, 0));
			if (facingRight)
			{
				Flip ();
			}
			facingRight = false;
		}
		if (Input.GetKey (KeyCode.D))
		{
			transform.Translate(new Vector3(moveSpeed, 0, 0));
			if(!facingRight)
			{
				Flip ();
			}
			facingRight = true;
		}
		//if (Input.GetKey (KeyCode.W))
		//{
		// transform.Translate(new Vector3(0,moveSpeed, 0));
		//}
		if (Input.GetKey (KeyCode.S))
		{
			transform.Translate(new Vector3(0,-moveSpeed, 0));
		}
		//if (temp = temp && !facingRight)
		// Flip ();
		//else if (temp = temp && facingRight)
		// Flip ();
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D( Collider2D other )
	{
		if (!isInvincible && other.CompareTag("enemy"))
		{
			isInvincible = true;
			timeSpentInvincible = 0;
			if (--lives <= 0) {
				Debug.Log("You lost!");
			}
		}
	}
}