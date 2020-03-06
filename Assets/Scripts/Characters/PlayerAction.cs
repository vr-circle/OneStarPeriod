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
				private Animator animator;


				[SerializeField]
				private BulletController bulletController;

				void Start()
				{
					animator = this.GetComponent<Animator>();

					bulletController = GetComponent<BulletController>();
				}

				void Update()
				{
					Action();
				}

				private void Action()
				{
					if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.F))//left
					{
						animator.SetBool("isShooting", true);
						if (Input.GetMouseButton(0))
						{
							bulletController.CommonShoot();
						}
						else if (Input.GetKey(KeyCode.F))
						{
							bulletController.ShootStrongBullet();
						}
					}
					else
					{
						animator.SetBool("isShooting", false);
					}
					

					if (Input.GetMouseButton(1))//right
					{
						LockOn();
					}


				}


				private void LockOn()
				{
					//Debug.Log("lock on");
				}


			}
		}
	}
}