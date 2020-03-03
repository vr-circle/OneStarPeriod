using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace OneStarPeriod
{
	namespace Character
	{
		namespace Bot
		{


			public class Supportlooking : MonoBehaviour
			{
				[SerializeField] GameObject Bot;
				private GameObject NearEnemy;
				private float searchTime;

				void Start()
				{
					//最も近かったオブジェクトを取得
					NearEnemy = serchTag(gameObject, "Enemy");
				}

				void Update()
				{

					//経過時間を取得
					searchTime += Time.deltaTime;

					if (searchTime >= 1.0f)
					{
						//最も近かったオブジェクトを取得
						NearEnemy = serchTag(gameObject, "Enemy");

						//経過時間を初期化
						searchTime = 0;
					}

					//対象の位置の方向を向く
					float speed = 2.0f;

					Vector3 relativePos = NearEnemy.transform.position - this.transform.position;

					Quaternion rotation = Quaternion.LookRotation(relativePos);

					transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);
				}

				//指定されたタグの中で最も近いものを取得
				GameObject serchTag(GameObject nowObj, string tagName)
				{
					float tmpDis = 0;           //距離用一時変数
					float nearDis = 0;          //最も近いオブジェクトの距離
												//string nearObjName = "";    //オブジェクト名称
					GameObject targetObj = null; //オブジェクト

					//タグ指定されたオブジェクトを配列で取得する
					foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
					{
						//自身と取得したオブジェクトの距離を取得
						tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

						//オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
						//一時変数に距離を格納
						if (nearDis == 0 || nearDis > tmpDis)
						{
							nearDis = tmpDis;
							//nearObjName = obs.name;
							targetObj = obs;
						}

					}
					//最も近かったオブジェクトを返す
					//return GameObject.Find(nearObjName);
					return targetObj;
					// Update is called once per frame
				}
			}
		}
	}
}