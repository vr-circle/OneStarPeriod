using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character
{
	interface IcanLockedOn
	{
		void LockedOn();
	}

	interface IDamageable
	{
		void ApplyDamage(float damage);
	}

}