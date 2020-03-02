using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//[SerializeField]
	//private Status status;

	[SerializeField]
	private GameObject gun;
	[SerializeField]
	private Weapon.GunController gunController;

	void Start()
	{
		gunController = gun.GetComponent<Weapon.GunController>();
	}

	void Update()
	{
		Action();
	}

	private void FixedUpdate()
	{

	}

	private void Action()
	{
		if (Input.GetMouseButton(0))
		{
			gunController.Shoot();
		}
	}



}
