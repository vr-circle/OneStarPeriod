using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OneStarPeriod
{
	namespace Weapon
	{
		public class BulletController : MonoBehaviour
		{
			[SerializeField]
			private GameObject bullet;

			private float bulletSpeed = 20.0f;

			private int bulletNum = 100000;

			private float positionMargin = 1.0f;



			private bool isShooted = false;
			private float timeInterval = 0.1f;
			private float elapsedTime = 0.0f;

			public Rect BulletNumDispPos = new Rect(0, 0, 100, 50);  // 場所は後で決める


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

			}


			public void Shoot()
			{
				if (!isShooted)
				{
					isShooted = true;

					Vector3 startPosition = this.transform.position;
					startPosition += this.transform.forward * positionMargin;
					GameObject bulletTmp = Instantiate(bullet, startPosition, this.transform.rotation);
					bulletTmp.GetComponent<Rigidbody>().velocity = this.transform.forward * bulletSpeed;
				}
			}

		}
	}
}