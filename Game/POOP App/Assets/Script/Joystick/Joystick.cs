﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour {

	public Transform player;
	public float speed;
	private bool touchStart = false;

	private Vector2 pointA;
	private Vector2 pointB;

	public Transform innerCircle;
	public Transform outerCircle;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButtonDown(0))
		{
			pointA = Camera.main.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z ) );

			innerCircle.transform.position = pointA;
			outerCircle.transform.position = pointA;
			innerCircle.GetComponent<SpriteRenderer>().enabled = true;
			outerCircle.GetComponent<SpriteRenderer>().enabled = true;
		}
		if(Input.GetMouseButton(0))
		{
			touchStart = true;
			pointB = Camera.main.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z ) );
		}
		else
		{
			touchStart = false;
		}	
	}

	void FixedUpdate()
	{
		
		if(touchStart)
		{
			Vector2 offset = pointB - pointA;
			Vector2 direction = Vector2.ClampMagnitude( offset, 1.0f );
			moveCharacter( direction );

			//innerCircle.transform.position = new Vector2( pointA.x + direction.x, pointA.y + direction.y );
			innerCircle.transform.position = new Vector2( outerCircle.transform.position.x + direction.x, outerCircle.transform.position.y + direction.y );
		}
		else
		{
			innerCircle.GetComponent<SpriteRenderer>().enabled = false;
			outerCircle.GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	void moveCharacter(Vector2 direction)
	{
		player.Translate(direction * speed * Time.deltaTime);
	}
}
