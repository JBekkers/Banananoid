using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{
    private float cooldown;
    public List<GameObject> BananaAmmo;
    public Image[] BananaUI;
    public int AmmoCount = 5;
    public GameObject UImodel;
    private GameObject Banana;
    public GameObject prefab;
    public List<GameObject> Bananaleft;
    public static ShootController instance { get; private set; }

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

    void Update()
    {
        cooldown -= Time.deltaTime;
        Bananaleft = new List< GameObject > (GameObject.FindGameObjectsWithTag("Banana"));

        if(Bananaleft.Count <= 0)
        {
            playercontroller.instance.GameEnd = true;
        }

        if ((Input.GetKeyDown(KeyCode.Mouse0)) && cooldown < 0 && AmmoCount > 0)
        {
            Banana = Instantiate(prefab, new Vector3(0, 0f, 0f), Quaternion.identity) as GameObject;
            Transform parent = UImodel.GetComponent<Transform>();
            Banana.transform.position = parent.position;
            Banana.transform.rotation = parent.rotation;
            cooldown = 1;
            AmmoCount -= 1;
        }

        for (int i = 0; i < BananaAmmo.Count; i++)
        {
            if (i < AmmoCount)
            {
                BananaAmmo[i].gameObject.SetActive(true);
                BananaUI[i].enabled = true;
            }

            else
            {
                BananaAmmo[i].gameObject.SetActive(false);
                BananaUI[i].enabled = false;
            }
        }
    }
}
