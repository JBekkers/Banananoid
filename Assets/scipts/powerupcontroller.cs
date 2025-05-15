using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupcontroller : MonoBehaviour
{
    private float time;
    private void Start()
    {
        time = 12;
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if(time < 0)
        {
            Destroy(this.gameObject);
        }
    }
    
 
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("test");

        if (col.gameObject.CompareTag("Player"))
        {
            if (ShootController.instance.AmmoCount < 5)
            {
                ShootController.instance.AmmoCount++;
            }
            Destroy(this.gameObject);
        }
    }
}
