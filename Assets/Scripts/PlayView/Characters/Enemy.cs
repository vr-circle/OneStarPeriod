﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Character
{
	public class Enemy : MonoBehaviour, IcanLockedOn, IDamageable
	{
		private float hp;
		private float maxHp = 30.0f;

		private Slider slider;

		private void Start()
		{
			hp = maxHp;

			slider = this.gameObject.transform.Find("HPBar/Slider").gameObject.GetComponent<Slider>();

		}

		private void Update()
		{
			Debug.Log(hp);

			slider.value = hp / maxHp;
			if (hp <= 0)
			{
				Destroy(this.gameObject);
			}

		}



		public void ApplyDamage(float damage)
		{

			hp -= damage;

		}

		public void LockedOn()
		{
			//UIを更新する,PlayerControllerから実行させる
			Debug.Log("locked on");
		}
	}
}