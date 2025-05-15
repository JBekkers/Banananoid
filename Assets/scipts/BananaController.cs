 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaController : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody rb;
    private float returntimer;
    public int speed;
    private float turntimer;

    private Vector3 velocity;
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        returntimer = 3;
        velocity = Camera.main.transform.forward * speed;
        //rb.AddForce(Camera.main.transform.forward * speed * Time.deltaTime, ForceMode.VelocityChange);
    }

    void Update()
    {
        rb.velocity = velocity;

        //BOOMERANG EFFECT
        returntimer -= Time.deltaTime;

        //COMBO MULTIPLIER
        if (returntimer < 0 && returntimer > -1)
        {       
           //Debug.Log("test");
        }

        if (ScoreBehavour.instance.combotimer < 0)
        {
            ScoreBehavour.instance.multiplier = 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);

        //COMBO MULTIPLIER
        if (collision.gameObject.CompareTag("Monkey"))
        {
            ScoreBehavour.instance.combotimer = 3;
        }

        if (collision.gameObject.CompareTag("Monkey") && ScoreBehavour.instance.combotimer > 0)
        {
            ScoreBehavour.instance.multiplier++;
        }

        if (collision.gameObject.CompareTag("Bananabarrier"))
        {
            Destroy(this.gameObject);
        }
    }
}
