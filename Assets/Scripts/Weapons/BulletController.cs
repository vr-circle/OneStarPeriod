﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OneStarPeriod
{
	namespace Weapon
	{
		using Character.Player;
		public class BulletController : MonoBehaviour
		{
			[SerializeField]
			private PlayerStatus playerStatus;

			[SerializeField]
			private GameObject bullet;
			[SerializeField]
			private GameObject strongBullet;



			private float bulletSpeed = 20.0f;

			private int bulletNum = 100000;

			private float positionMargin = 1.5f;

			private float necessaryMp = 40.0f;

			private bool isShooted = false;
			private float timeInterval = 0.1f;
			private float elapsedTime = 0.0f;

			private void Start()
			{
				playerStatus = GetComponent<PlayerStatus>();
			}


			private void Update()
			{
				if (isShooted)
				{
					elapsedTime += Time.deltaTime;


					if (elapsedTime > timeInterval)
					{
						isShooted = false;

						elapsedTime = 0.0f;

					}
				}
			}

			public void ShootStrongBullet()
			{
				if (!isShooted)
				{
					isShooted = true;
					if (this.playerStatus.GetMp() > necessaryMp)
					{
						playerStatus.DecreaseMp(necessaryMp);
						Shoot(strongBullet);
					}
				}
			}


			public void CommonShoot()
			{
				if (!isShooted)
				{
					isShooted = true;
					Shoot(this.bullet);
				}
			}

			private void Shoot(GameObject bullet)
			{
				Vector3 startPosition = this.transform.position;
				startPosition += this.transform.forward * positionMargin;
				GameObject bulletTmp = Instantiate(bullet, startPosition, this.transform.rotation);
				bulletTmp.GetComponent<Rigidbody>().velocity = this.transform.forward * bulletSpeed;

				Destroy(bulletTmp,5.0f);

			}




		}
	}
}