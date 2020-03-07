using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OneStarPeriod
{
	namespace Character
	{
		namespace Player
		{
			public class PlayerStatus : MonoBehaviour, IDamageable
			{
				[SerializeField]
				private GameObject hpBar;
				[SerializeField]
				private float maxHp;
				private float hp;
				private Slider hpSlider;

				[SerializeField]
				private GameObject mpBar;
				[SerializeField]
				private float maxMp = 50.0f;
				private float mp;
				private float mpRecoverySpeed = 0.1f;
				private Slider mpSlider;

				private GameObject mainCamera;
				private CameraController cameraController;

				private AudioSource audioSource;
				[SerializeField]
				AudioClip getDamageSound;
				[SerializeField]
				AudioClip healing;


				private float elapsedTime = 0.0f;
				private float timeInterval = 1.0f;
				private bool canGetDamage = true;

				private void Start()
				{
					audioSource = GetComponent<AudioSource>();

					mainCamera = this.transform.Find("MainCamera").gameObject;
					cameraController = mainCamera.GetComponent<CameraController>();

					hp = maxHp;
					mp = maxMp;

					hpSlider = hpBar.GetComponent<Slider>();
					mpSlider = mpBar.GetComponent<Slider>();
				}

				private void Update()
				{
					if (hp <= 0.0f)
					{
						FadeManager.FadeOut("GameOver");
					}

					hpSlider.value = hp / maxHp;
					mpSlider.value = mp / maxMp;

					if (canGetDamage == false)
					{
						elapsedTime += Time.deltaTime;
						if (elapsedTime > timeInterval)
						{
							elapsedTime = 0;
							canGetDamage = true;
						}
					}
				}
				private void LateUpdate()
				{
					mp += mpRecoverySpeed;
					mp = Mathf.Min(mp, maxMp);
				}

				public void ApplyDamage(float damage)
				{
					if (canGetDamage)
					{
						if (damage > 0)
						{
							canGetDamage = false;
							audioSource.PlayOneShot(getDamageSound);
							cameraController.Shake(0.2f, 0.08f);
						}
						else
						{
							audioSource.PlayOneShot(healing);
						}
						this.hp -= damage;
						hp = Mathf.Min(hp, maxHp);
					}
				}


				public float GetMp()
				{
					return this.mp;
				}
				public void DecreaseMp(float mp)
				{
					this.mp -= mp;
				}





			}
		}
	}
}