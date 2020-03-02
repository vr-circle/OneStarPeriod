﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace StageSelect
{
	public class ButtonDirector : MonoBehaviour
	{
		[SerializeField]
		private GameObject mainCanvas;


		[SerializeField]
		private GameObject buttonPrefab;
		
		
		[SerializeField]
		private List<Scene> stages;


		void Start()
		{
			for (int i = 1; i < stages.Count + 1; i++)
			{
				float xMargin = 100;
				float yMargin = -200;
				Vector3 buttonPosition = new Vector3(i * xMargin, yMargin, 0);


				GameObject buttonObject = (GameObject)Instantiate(this.buttonPrefab, buttonPosition, Quaternion.identity);
				buttonObject.transform.SetParent(mainCanvas.transform, false);

				Button button = buttonObject.GetComponent<Button>();
				button.onClick.AddListener(() =>
				{
					Debug.Log(i);
					//ここ上手くいっていない
					//各シーンの読み込み処理
				});

				Text t = button.transform.FindChild("Text").gameObject.GetComponent<Text>();

				t.text = "Stage" + i.ToString();

			}
		}
	}
}