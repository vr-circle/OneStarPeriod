using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OneStarPeriod
{
	public class GameDirector : MonoBehaviour
	{
		private static uint score = 0;

		private static float time = 0.0f;

		private static bool isPlaying;


		private void Start()
		{
			score = 0;
			time = 0.0f;
			isPlaying = true;
		}

		private void FixedUpdate()
		{
			if (isPlaying)
			{
				time += Time.deltaTime;
			}
		}

		static float GetScore()
		{
			return score;
		}
		static float GetTime()
		{
			return time;
		}



	}
}