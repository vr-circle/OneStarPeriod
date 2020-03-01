using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character
{
	public class EnemyUIManager : MonoBehaviour
	{
		private void LateUpdate()
		{
			transform.rotation = Camera.main.transform.rotation;
		}
	}
}