using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character
{
	public class Status
	{
		private float hp;
		//private float mp;


		public void GetDamage(float damage)
		{
			hp -= damage;
		}
	}
}