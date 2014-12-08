using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public float speed = 3.0f;
	public float pacelength = 2.0f;
	float origX;
	// Use this for initialization
	void Start ()
	{
		//Vector3 origPosition = transform.position;
		origX = transform.position.x;
	}
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(speed*Time.deltaTime,0,0);
		if(Mathf.Abs(origX - transform.position.x) > pacelength)
		{
			speed *= -1.0f; //change direction
		}
	}
}
