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
				private float hp;
				private float maxHp = 50.0f;
				private float mp;
				private float maxMp = 50.0f;
				private float mpRecoverySpeed = 0.1f;

				[SerializeField]
				private GameObject hpBar;
				[SerializeField]
				private GameObject mpBar;

				private Slider hpSlider;
				private Slider mpSlider;

				private GameObject mainCamera;
				private CameraController cameraController;

				private AudioSource audioSource;
				[SerializeField]
				AudioClip getDamageSound;


				private float elapsedTime = 0.0f;
				private float timeInterval = 0.1f;
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
						//GameOverSceneに遷移させる
						FadeManager.FadeOut("ResultScene");
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
				}

				private void FixedUpdate()
				{
				}


				public void ApplyDamage(float damage)
				{
					if (canGetDamage)
					{

						canGetDamage = false;

						audioSource.PlayOneShot(getDamageSound);

						cameraController.Shake(0.2f, 0.08f);

						this.hp -= damage;
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