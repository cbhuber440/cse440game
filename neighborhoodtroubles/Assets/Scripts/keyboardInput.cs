using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class keyboardInput : MonoBehaviour {
	public int walkCycleFrames;
	public string spriteSheetName;
	public int animationStep;
	public float moveSpeed;

	private bool facingRight = true;
	private bool isWalking = false;

	private int index = 0;
	private int frameCount = 0;

	private Sprite nextSprite;
	private SpriteRenderer sRenderer;

	void Start ()
	{
		sRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	void Update () {
		movement ();
		if (isWalking) {
			frameCount++;
			if(frameCount >= animationStep) {
				if(index < walkCycleFrames) {
					index++;
					nextSprite.name = spriteSheetName + index.ToString();
					sRenderer.sprite = nextSprite;
				}
				else {
					index = 0;
					
					nextSprite.name = spriteSheetName + index.ToString();
					sRenderer.sprite = nextSprite;
				}
				frameCount = 0;
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
			isWalking = true;
			facingRight = false;
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Translate(new Vector3(moveSpeed, 0, 0));
			if(!facingRight)
			{
				Flip ();
			}
			isWalking = true;
			facingRight = true;
		}
		//if (Input.GetKey (KeyCode.W)) 
		//{
		//	transform.Translate(new Vector3(0,moveSpeed, 0));
		//}

		if (Input.GetKey (KeyCode.S)) {
						transform.Translate (new Vector3 (0, -moveSpeed, 0));
				}
		//if (temp = temp && !facingRight) 
		//		Flip ();
		//else if (temp = temp && facingRight)
		//		Flip ();
		else {
			isWalking = false;
		}
	}


	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
}