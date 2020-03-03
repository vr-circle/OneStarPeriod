using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportTokenProcess : MonoBehaviour
{
    [SerializeField]
    private GameObject Supporter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(Supporter, this.transform.position, Quaternion.identity);

            Destroy(this.gameObject);

        }
    }

}
