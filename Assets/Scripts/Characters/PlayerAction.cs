using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character
{
	namespace Player
	{
		public class PlayerAction : MonoBehaviour//, IDamageable
		{

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

			private void Action()
			{
				if (Input.GetMouseButton(0))//left
				{
					gunController.Shoot();
				}

				if (Input.GetMouseButton(1))//right
				{
					LockOn();
				}
			}


			private void LockOn()
			{
				Debug.Log("lock on");
			}


		}
	}
}