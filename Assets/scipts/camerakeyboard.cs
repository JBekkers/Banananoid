using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerakeyboard : MonoBehaviour
{
    public int mousesens;
    public Transform player;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mousesens = 300;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Rotate(0, -0.5f * mousesens * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Rotate(0, 0.5f * mousesens * Time.deltaTime, 0);
        }
    }
}