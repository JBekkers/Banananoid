using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject selectionArrow;
    public GameObject Button;
    public GameObject music;
    int selected = 1;

    // Start is called before the first frame update
    void Start()
    {
        toggleSelection();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            toggleSelection();
        }

        music = GameObject.FindGameObjectWithTag("music");

        if (Input.GetKeyDown(KeyCode.Return))
        {

            if (selected == 0)
            {
                Destroy(music);
                SceneManager.LoadScene("GameScene");            
            }
            else
            {
                SceneManager.LoadScene("HTP");
            }
        } 

        //  quit game
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void toggleSelection()
    {
        if (selected == 0)
        {
            selected = 1;
        }
        else
        {
            selected = 0;
        }
        selectionArrow.transform.position = buttons[selected].transform.position;
        Button.transform.position = buttons[selected].transform.position;
    }
}
