using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class EventsController : MonoBehaviour
{
    [Header("Time")]
    public float timeRemaning;
    [SerializeField] TextMeshProUGUI txt_timer;
    [Header("Panels")]
    [SerializeField] GameObject panelPlay;
    [SerializeField] GameObject panelInGame;
    [SerializeField] GameObject panelGameOver;
    [SerializeField] GameObject panelGameWon;
    [Header("Other")]
    [SerializeField] Button buttonPlay;
    int points = 0;
    

    void Start()
    {
        Time.timeScale = 0;
        panelPlay.SetActive(true);
        panelInGame.SetActive(false);
        panelGameOver.SetActive(false);
        panelGameWon.SetActive(false);
    }

    
    void Update()
    {
        if (timeRemaning > 0)
        {
            timeRemaning -= Time.deltaTime;
        } 
        else if (timeRemaning < 0)
        {
            timeRemaning = 0;
            Time.timeScale = 0;
        }

        int min = Mathf.FloorToInt(timeRemaning / 60);
        int sec = Mathf.FloorToInt(timeRemaning % 60);
        txt_timer.text = string.Format("{0:00}:{1:00}",min, sec);
    }


    public void StartGame()
    {
        Time.timeScale = 1;
        timeRemaning = 120;
        points = 0;
        panelPlay.SetActive(false);
        panelInGame.SetActive(true);
        panelGameOver.SetActive(false);
        panelGameWon.SetActive(false);
    }
    
}
