using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OneStarPeriod
{
	public class Pauser : MonoBehaviour
	{
		[SerializeField]
		private GameObject textUI;
		private Text text;

		private bool isCounting = true;

		private void Start()
		{
			text = textUI.GetComponent<Text>();
		}
		private void Update()
		{
			//if(isCounting)
				//CountDown();
		}

		private void CountDown()
		{

			Time.timeScale = 0.0f;
		}


		//private IEnumerator CountDown()
		//{
		//	int time = 3;
		//		Debug.Log(time);
		//	Time.timeScale = 0.0f;

		//	while (time >= 0)
		//	{
		//		time--;
		//		//text.text = time.ToString();
		//		yield return new WaitForSeconds(1.0f);
		//	}

		//	isCounting = false;
		//	Time.timeScale = 1.0f;

		//}

	}
}