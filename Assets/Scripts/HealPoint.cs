using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneStarPeriod
{
    namespace Character
    {
        public class HealPoint : MonoBehaviour
        {
            private float deltaTime;
            private int nowTime;

            private void Start()
            {
                this.gameObject.transform.position = new Vector3(-15.22f, 2f, -14.19f);
            }

            private void Update()
            {
                this.gameObject.transform.Rotate(new Vector3(0, 5, 0));
                deltaTime += Time.deltaTime;
                nowTime = (int)deltaTime;
                if (nowTime > 15)
                {
                    GetComponent<MeshRenderer>().enabled = true;
                    GetComponent<BoxCollider>().enabled = true;
                }
            }

            void OnCollisionEnter(Collision collision)
            {
                IDamageable idamageable = collision.gameObject.GetComponent<IDamageable>();

                if (idamageable != null)
                {
                    Debug.Log("ok");
                    idamageable.ApplyDamage(-15);
                    Destroy(this.gameObject);
                }
            }

        }
    }
}
