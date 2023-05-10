using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;


public class Gameover : MonoBehaviour
{
    public Text pointText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointText.text = "Score: " + score.ToString();
    }
  
}
