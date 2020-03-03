using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OneStarPeriod
{
	namespace TitleScene
	{

		public class Blink : MonoBehaviour
		{
			private float speed = 0.7f;

			private Text text;
			private Image image;
			private float time;

			private enum ObjType
			{
				Text,
				Image
			};
			private ObjType thisObjType = ObjType.Text;
			private void Start()
			{
				if (this.gameObject.GetComponent<Image>())
				{
					thisObjType = ObjType.Image;
					image = this.gameObject.GetComponent<Image>();
				}
				else if (this.gameObject.GetComponent<Text>())
				{
					thisObjType = ObjType.Text;
					text = this.gameObject.GetComponent<Text>();
				}
			}

			void Update()
			{
				if (thisObjType == ObjType.Image)
				{
					image.color = GetAlphaColor(image.color);
				}
				else if (thisObjType == ObjType.Text)
				{
					text.color = GetAlphaColor(text.color);
				}
			}

			Color GetAlphaColor(Color color)
			{
				time += Time.deltaTime * 5.0f * speed;
				color.a = Mathf.Sin(time) * 0.5f + 0.5f;

				return color;
			}
		}
	}
}