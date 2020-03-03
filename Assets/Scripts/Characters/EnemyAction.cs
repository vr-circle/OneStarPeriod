using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneStarPeriod
{
	namespace Character
	{
		namespace Enemy
		{

			public class EnemyAction : MonoBehaviour
			{
				[SerializeField]
				private GameObject bullet;

				private float bulletSpeed = 20.0f;

				private float positionMargin = 1.0f;



				private bool isShooted = false;
				private float timeInterval = 0.5f;
				private float elapsedTime = 0.0f;

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
					else
					{
						Shoot();
					}
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
}