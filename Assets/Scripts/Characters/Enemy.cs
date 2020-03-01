using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
	public class Enemy : MonoBehaviour, IcanLockedOn, IDamageable
	{
		[SerializeField]
		private float hp;


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
