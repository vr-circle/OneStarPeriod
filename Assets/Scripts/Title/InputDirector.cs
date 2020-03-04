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
			private void Update()
			{
				if ((Input.GetKeyDown(KeyCode.KeypadEnter)) || (Input.GetMouseButtonDown(0)))
				{
					FadeManager.FadeOut("StageSelect");
				}
			}
		}
	}
}