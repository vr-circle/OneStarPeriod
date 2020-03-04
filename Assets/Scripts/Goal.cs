using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace OneStarPeriod
{

	public class Goal : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Player")
			{
				//FadeManager.FadeOut("Stage1");


			}
		}
	}
}