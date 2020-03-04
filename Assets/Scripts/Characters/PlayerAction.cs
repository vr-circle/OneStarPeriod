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

				//[SerializeField]
				//private GameObject gun;
				[SerializeField]
				private BulletController bulletController;

				void Start()
				{
					bulletController = GetComponent<BulletController>();
				}

				void Update()
				{
					Action();
				}

				private void Action()
				{
					if (Input.GetMouseButton(0))//left
					{
						bulletController.Shoot();
					}

					if (Input.GetMouseButton(1))//right
					{
						LockOn();
					}

					if (Input.GetKey(KeyCode.F))
					{

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