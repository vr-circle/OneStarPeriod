using System.Collections;
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
			private float positionMargin = 1.5f;
			private float yPositionMargin = 1.0f;


			private float necessaryMp = 20.0f;
			private bool isShooted = false;
			private bool isDecrease = false;

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

			private void LateUpdate()
			{
				if (isDecrease)
				{
					playerStatus.DecreaseMp(necessaryMp);
					isDecrease = false;
				}
			}

			public void ShootStrongBullet()
			{
				if (!isShooted)
				{
					isShooted = true;
					if (this.playerStatus.GetMp() > necessaryMp)
					{
						Shoot(strongBullet);
						isDecrease = true;
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
				startPosition += new Vector3(0, yPositionMargin, 0);


				GameObject bulletTmp = Instantiate(bullet, startPosition,Quaternion.identity);

				bulletTmp.transform.rotation = this.transform.rotation * Quaternion.Euler(-90, 0, 0);

				Vector3 direction = this.transform.forward;

				direction.y = 0;

				bulletTmp.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;

				Destroy(bulletTmp, 5.0f);

			}




		}
	}
}