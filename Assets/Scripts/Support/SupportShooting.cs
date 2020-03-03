using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportShooting : MonoBehaviour
{
	[SerializeField]
	private GameObject Supportbullet;

	private float bulletSpeed = 20.0f;

	private int bulletNum = 100000;

	private float positionMargin = 1.0f;

	private GameObject NearEnemy;

	private bool isShooted = false;

	private float timeInterval = 1.0f;

	private float elapsedTime = 0.0f;


	//public Rect BulletNumDispPos = new Rect(0, 0, 100, 50);  // 場所は後で決める


	private void Update()
	{
		NearEnemy = this.GetComponent<Supportlooking>().FindNearEnemy();
		if (NearEnemy != null)
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
			Shoot();
		}
	}


	private void Shoot()
	{
		if (!isShooted)
		{

			if (bulletNum > 0)
			{

				isShooted = true;


				Vector3 startPosition = this.transform.position;

				startPosition += this.transform.forward * positionMargin;

				GameObject bulletTmp = Instantiate(Supportbullet, startPosition, this.transform.rotation);

				bulletTmp.GetComponent<Rigidbody>().velocity = this.transform.forward * bulletSpeed;

				bulletNum--;
			}
			else
			{
				//弾切れ
			}
		}
	}
}