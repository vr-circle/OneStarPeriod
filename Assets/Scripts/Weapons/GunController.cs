using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Weapon
{
	public class GunController : MonoBehaviour
	{
		[SerializeField]
		private GameObject bullet;

		private float bulletSpeed = 20.0f;

		private int bulletNum = 100000;

		private float positionMargin = 1.0f;

		private GUIStyle bulletNumGUI;

		private bool isShooted = false;
		private float timeInterval = 0.1f;
		private float elapsedTime = 0.0f;


		private void Start()
		{
			bulletNumGUI = new GUIStyle
			{
				fontSize = 40,
				// TODO: フォントもいい感じのやつにする
			};
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


		public void Shoot()
		{
			if (!isShooted)
			{

				if (bulletNum > 0)
				{

					isShooted = true;


					Vector3 startPosition = this.transform.position;

					startPosition += this.transform.forward * positionMargin;

					GameObject bulletTmp = Instantiate(bullet, startPosition, this.transform.rotation);

					bulletTmp.GetComponent<Rigidbody>().velocity = this.transform.forward * bulletSpeed;

					bulletNum--;
				}
				else
				{
					//弾切れ
				}
			}
		}

		public void OnGUI()
		{
			GUI.Label(new Rect(0, Screen.height-40, 100, 50), bulletNum.ToString(), bulletNumGUI);
		}

	}
}