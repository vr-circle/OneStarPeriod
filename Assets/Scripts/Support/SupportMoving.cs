using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportMoving : MonoBehaviour
{
	//[SerializeField]
	//private GameObject support;

	[SerializeField]
	private GameObject player;

	private float distance;

	private Vector3 supportVerocity;

	private Vector3 playerPosition;

	private Vector3 supportDirection;

	[SerializeField]
	private float supportSpeed = 1.0f;

	// Update is called once per frame
	void Update()
	{
		playerPosition = player.transform.position;
		distance = Vector3.Distance(this.transform.position, player.transform.position);
		supportDirection = playerPosition - this.transform.position;
		supportVerocity = supportDirection * supportSpeed;

		if (distance >= 2.0f)
		{
			this.transform.position += supportVerocity * Time.deltaTime;
		}
	}
}
