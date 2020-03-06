using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OneStarPeriod
{
	public class GameDirector : MonoBehaviour
	{
		private uint score = 0;

		private float time = 0.0f;


		private void Start()
		{
			score = 0;
			time = 0.0f;
		}

		private void FixedUpdate()
		{
			time += Time.deltaTime;
		}



	}
}