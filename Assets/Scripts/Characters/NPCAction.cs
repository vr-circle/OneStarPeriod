using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneStarPeriod
{
	namespace Character
	{
		namespace Enemy
		{

			public class NPCAction : MonoBehaviour
			{
				[SerializeField]
				private float bodyDamage = 10.0f;

				[SerializeField]
				private GameObject bullet;

				private float bulletSpeed = 20.0f;
				private float positionMargin = 1.0f;


				[SerializeField]
				private float timeInterval = 0.5f;
				private bool isShooted = true;
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

				private void OnCollisionEnter(Collision collision)
				{
					if(collision.gameObject.tag == "Enemy")
					{
						return;
					}

					IDamageable idamageable = collision.gameObject.GetComponent<IDamageable>();

					if (idamageable != null)
					{
						idamageable.ApplyDamage(bodyDamage);
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

						bulletTmp.transform.rotation = this.transform.rotation * Quaternion.Euler(-90, 0, 0);


						bulletTmp.GetComponent<Rigidbody>().velocity = this.transform.forward * bulletSpeed;
					}
				}

			}
		}
	}
}