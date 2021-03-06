using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject RespawnPoint1;
    public GameObject RespawnPoint2;
    public GameObject UltimatePoint1;
    public GameObject UltimatePoint2;
    public GameObject UltimatePoint3;
    public GameObject Player1;
    public GameObject Player2;
    public float Score = 0.0f;
    private int p1Score = 0;
    private int p2Score = 0;
    public Text w_Text;
    public Text s_Text;
    public GameObject wText;
    public Text p1Health;
    public Text p2Health;
    public Text p1Ult;
    public Text p2Ult;
    public Slider p1HealthSlider;
    public Slider p2HealthSlider;
    private float pauseTimer = 3f;
    public Text StartTimerText;
    public GameObject StartTimerO;
    bool timerIsRunning = false;
    bool winner = false;
    GameObject[] ability;

    // Start is called before the first frame update
    void Start()
    {
        ability = GameObject.FindGameObjectsWithTag("Ability");

        Player1.transform.position = RespawnPoint1.transform.position;
        Player1.transform.rotation = RespawnPoint1.transform.rotation;
        Player1.SetActive(enabled);

        Player2.transform.position = RespawnPoint2.transform.position;
        Player2.transform.rotation = RespawnPoint2.transform.rotation;
        Player2.GetComponent<PlayerMovementController>().movingRight = false;
        Player2.SetActive(enabled);

        RoundPauser();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Player2.activeSelf && !Player1.activeSelf)
        {
            Respawn();
            if (!winner)
            {
            w_Text.text = "Draw";
            wText.SetActive(enabled);
            }

        }
        if(!Player2.activeSelf)
        {
            Debug.Log("Player1: "+Player1.activeInHierarchy);
            Debug.Log("Player2: "+Player2.activeInHierarchy);
            if (!winner)
            {
                p1Score++;
                Score = Score + 1.0f;
            }
            Respawn();
        }
       if (!Player1.activeSelf)
       {
            Debug.Log("Player1: " + Player1.activeInHierarchy);
            Debug.Log("Player2: " + Player2.activeInHierarchy);
            if (!winner)
            {
                p2Score++;
                Score = Score + 0.1f;
            }
            Respawn();
        }
        if (Player1.GetComponent<PlayerHealth>().p_UltimatePoint == 2)
        {
            p1Ult.text = "Ult: READY!";
        } else if(Player1.GetComponent<PlayerHealth>().p_UltimatePoint < 2)
        {
            p1Ult.text = "Ult: Not ready";
        }
        if (Player2.GetComponent<PlayerHealth>().p_UltimatePoint == 2)
        {
            p2Ult.text = "Ult: READY!";
        }
        else if (Player2.GetComponent<PlayerHealth>().p_UltimatePoint < 2)
        {
            p2Ult.text = "Ult: Not ready";
        }
        p1Health.text = ""+Player1.GetComponent<PlayerHealth>().p_CurrentHealth;
        p2Health.text = ""+Player2.GetComponent<PlayerHealth>().p_CurrentHealth;
        p1HealthSlider.value = Player1.GetComponent<PlayerHealth>().p_CurrentHealth / 100;
        p2HealthSlider.value = Player2.GetComponent<PlayerHealth>().p_CurrentHealth / 100;

        if (timerIsRunning)
        {
            if (pauseTimer > 0f)
            {
                StartTimerText.text = "" + pauseTimer.ToString("0.0");
                pauseTimer -= Time.deltaTime;
            }else if (pauseTimer < 0f && pauseTimer > -0.5f)
            {
                pauseTimer -= Time.deltaTime;
                StartTimerText.text = "GO!";
                wText.SetActive(false);
            }
            else
            { 
                //Debug.Log("Time has run out!");
                timerIsRunning = false;
                StartTimerO.SetActive(false);
                pauseTimer = 3f;
            }
        }


    }

    void Respawn()
    {
        s_Text.text = "" + Score.ToString("0.0");
        ability = GameObject.FindGameObjectsWithTag("Ability");

        foreach (GameObject a in ability)
        {
            a.SetActive(false);
        }

        Player2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Player1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        
        Player2.transform.position = RespawnPoint2.transform.position;
        Player2.transform.rotation = RespawnPoint2.transform.rotation;
        Player2.GetComponent<PlayerMovementController>().movingRight = false;

        Player1.transform.position = RespawnPoint1.transform.position;
        Player1.transform.rotation = RespawnPoint1.transform.rotation;
        
        Player2.SetActive(false);
        Player1.SetActive(false);
        Player2.SetActive(enabled);
        Player1.SetActive(enabled);
        
        UltimatePoint1.transform.GetChild(0).gameObject.SetActive(enabled);
        UltimatePoint2.transform.GetChild(0).gameObject.SetActive(enabled);
        UltimatePoint3.transform.GetChild(0).gameObject.SetActive(enabled);

        if (p2Score == 3)
        {
            w_Text.text = "Player2 WINS!";
            wText.SetActive(enabled);
            winner = true;
        }
        if (p1Score == 3)
        {
            w_Text.text = "Player1 WINS!";
            wText.SetActive(enabled);
            winner = true;
        }
        if (!winner)
        {
            RoundPauser();
        }
    }
    void RoundPauser()
    {
        StartTimerO.SetActive(enabled);
        timerIsRunning = true;
        Player1.GetComponent<PlayerMovementController>().StartCoroutine("Stunned", pauseTimer);
        Player2.GetComponent<PlayerMovementController>().StartCoroutine("Stunned", pauseTimer);
    }

    public void QuitToMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        SceneManager.LoadScene("StartMenu");
    }
}
