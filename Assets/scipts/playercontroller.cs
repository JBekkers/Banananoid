using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public CharacterController controller;

    private Rigidbody rb;
    private int speed = 15;
    public bool GameEnd;

    public static playercontroller instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


        void Update()
    {
        //MOVEMENT
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);


        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(GameEnd == true)
        {
            SceneManager.LoadScene("gameover");
        }
    }
}
