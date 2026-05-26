using UnityEngine;
using TMPro;

public class EventsController : MonoBehaviour
{
    public float timeRemaning;
    [SerializeField] TextMeshProUGUI txt_timer;
    
    void Start()
    {
        
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
        }

        int min = Mathf.FloorToInt(timeRemaning / 60);
        int sec = Mathf.FloorToInt(timeRemaning % 60);
        txt_timer.text = string.Format("{0:00}:{1:00}",min, sec);
    }
}
