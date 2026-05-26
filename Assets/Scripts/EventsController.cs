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
    [Header("Other")]
    [SerializeField] TextMeshProUGUI txt_points;
    public int points;
    

    void Start()
    {
        Time.timeScale = 0;
        points = 0;
        panelPlay.SetActive(true);
        panelInGame.SetActive(false);
        panelGameOver.SetActive(false);
    }

    
    void Update()
    {
        if (timeRemaning > 0)
        {
            timeRemaning -= Time.deltaTime;
            txt_points.text = points.ToString();
        } 
        else if (timeRemaning < 0)
        {
            timeRemaning = 0;
            Time.timeScale = 0;
            panelPlay.SetActive(false);
            panelInGame.SetActive(false);
            panelGameOver.SetActive(true);
        }

        int min = Mathf.FloorToInt(timeRemaning / 60);
        int sec = Mathf.FloorToInt(timeRemaning % 60);
        txt_timer.text = string.Format("{0:00}:{1:00}",min, sec);
        txt_points.text = points.ToString();
    }


    public void StartGame()
    {
        Time.timeScale = 1;
        timeRemaning = 120;
        points = 0;
        panelPlay.SetActive(false);
        panelInGame.SetActive(true);
        panelGameOver.SetActive(false);
    }
    
}
