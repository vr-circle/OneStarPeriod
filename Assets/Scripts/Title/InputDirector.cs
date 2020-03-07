using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneStarPeriod
{
	namespace TitleScene
	{
		public class InputDirector : MonoBehaviour
		{
			private float nowTime = 0.0f;

			private float waitTime = 1.0f;


			private void Start()
			{
				nowTime = 0.0f;
			}


			private void Update()
			{
				if (waitTime < nowTime)
				{
					if (Input.anyKeyDown)
					{
						FadeManager.FadeOut("StageSelect");
					}
				}
			}
			private void FixedUpdate()
			{
				nowTime += Time.deltaTime;
			}

		}
	}
}