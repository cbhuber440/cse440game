﻿using UnityEngine;
using System.Collections;

public class killplayer : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col)
	{ if (col.gameObject.tag == "Player") 
		{ Destroy (col.gameObject); } 
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
