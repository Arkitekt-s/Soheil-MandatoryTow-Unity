using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeTarget=120;
    public TextMeshProUGUI timer;
    public Canvas canvas;
    public GameObject losepanel;
    public static bool isGameOver = false;
    
    
    
    

    // Update is called once per frame
    void Update()
    {
        if (timeTarget > 0)
        {
            timeTarget -= Time.deltaTime;
            ;
        }
        else
        {
            timeTarget = 0;
        }

        DisplayTime(timeTarget);
    }

    void DisplayTime(float timeToDisplay)
        {
            if (timeToDisplay< 0)
            {
                timeToDisplay = 0;
                
                showLosePanel();
                Time.timeScale = 0;
                isGameOver = true;
            }


            float minutes = Mathf.FloorToInt(timeTarget / 60);
            float seconds = Mathf.FloorToInt(timeTarget % 60);
            timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        }

        public void showLosePanel()
        {
            losepanel = Instantiate(losepanel);
            losepanel.SetActive(true);
            losepanel.AddComponent<CanvasRenderer>();
            losepanel.transform.SetParent(canvas.transform, false);
        }
    }

