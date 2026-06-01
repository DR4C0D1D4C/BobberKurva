using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using System.Collections.Generic;

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
    public List<HouseController> houseList;
    public int totalAsignedHouses;
    public GameObject player;

    void Start()
    {
        Time.timeScale = 0;
        points = 0;
        panelPlay.SetActive(true);
        panelInGame.SetActive(false);
        panelGameOver.SetActive(false);
        ResetHouses();
        AsignHouses();
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
        txt_timer.text = string.Format("{0:00}:{1:00}", min, sec);
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
        ResetHouses();
        AsignHouses();
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = new Vector3(6.5f, -0.5f, 0);
        player.GetComponent<CharacterController>().enabled = true;
    }

    public void Delivery()
    {
        points++;
        if (points == 3)
        {
            Time.timeScale = 0;
            panelPlay.SetActive(false);
            panelInGame.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }

    public void ResetHouses()
    {
        for (int i = 0; i < houseList.Count; i++)
        {
            houseList[i]._isDestination = false;
            houseList[i]._isDelivered = false;
        }
    }

    public void AsignHouses()
    {
        int id = 0;
        for (int i = 0; i < totalAsignedHouses; i++)
        {
            id = Random.Range(0, houseList.Count);
            if (!houseList[id]._isDestination)
            {
                houseList[id]._isDestination = true;
                houseList[id]._arrow.SetActive(true);
            }
            else
            {
                i--;
            }
        }
    }
}
