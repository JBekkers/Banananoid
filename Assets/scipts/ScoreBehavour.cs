using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBehavour : MonoBehaviour
{
    public int Score;
    private float Timer;
    public float combotimer;
    public int multiplier;
    public Text ScoreTxt;
    public Text combotxt;
    public Text wavetxt;
    private float ComboTimer;
    private bool Combo;

    private float survtimer;

    public static ScoreBehavour instance { get; private set; }

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
        multiplier = 1;
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (playercontroller.instance.GameEnd == false)
        {
            survtimer += Time.deltaTime;
        }

        Timer += Time.deltaTime;
        combotimer -= Time.deltaTime;

        ScoreTxt.text = Score.ToString();
        combotxt.text = multiplier + " X";
        wavetxt.text = monkeySpawner.instance.wave.ToString();

        if (playercontroller.instance.GameEnd == true)
        {
            Text endscore = GameObject.FindWithTag("Endscore").GetComponent<Text>() as Text;
            Text endtime = GameObject.FindWithTag("Endtime").GetComponent<Text>() as Text;
            Text endwave = GameObject.FindWithTag("Endwave").GetComponent<Text>() as Text;
            endscore.text = "you got " + Score + " points";
            endwave.text = "you survived for " + monkeySpawner.instance.wave + (monkeySpawner.instance.wave == 1 ? " Wave" : " Waves");
            endtime.text = "for a total of " + (int)survtimer + " Seconds";
        }

        if ((Input.GetKeyDown(KeyCode.Return)) && playercontroller.instance.GameEnd == true)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Menu");
        }
    }
}