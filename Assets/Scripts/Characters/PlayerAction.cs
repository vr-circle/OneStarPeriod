using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneStarPeriod
{
	namespace Character
	{
		namespace Player
		{
			using Weapon;
			public class PlayerAction : MonoBehaviour//, IDamageable
			{

				[SerializeField]
				private GameObject gun;
				[SerializeField]
				private GunController gunController;

				void Start()
				{
					gunController = gun.GetComponent<GunController>();
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
}