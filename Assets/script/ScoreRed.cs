using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreRed : MonoBehaviour
{
    public int scoreRed = 0;
    public TextMeshProUGUI scoreRedText;
    //show goal text
    public TextMeshProUGUI goalText;
    public AudioSource audioSource;
    public AudioClip goalSound;

    private const string SCORE_KEY = "scoreRed";

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("redteam"))
        {
            scoreRed++;
            scoreRedText.text = scoreRed.ToString();
            //HIDE THE TEXT THAND SHOW IT AGAIN AND HID IT AGAIN
            goalText.gameObject.SetActive(true);
            goalText.text = "GOAL!";

            StartCoroutine(HideGoalText());
            IEnumerator HideGoalText()
            {
                yield return new WaitForSeconds(5);
                goalText.gameObject.SetActive(false);
            }
            PlayerPrefs.SetInt(SCORE_KEY, scoreRed);
            if (goalSound != null)
            {
                audioSource.PlayOneShot(goalSound);
            }
            else
            {
                Debug.LogWarning("No goal sound found!");
            }
        }
        
        
        
    }
     //move ball to centre after goal
     void OnTriggerExit(Collider other)
     {
         if (other.gameObject.CompareTag("ball"))
         {
             other.gameObject.transform.position = new Vector3(0f, 0.5f, 0f);
         }
     }

     

    private void Start()
    {
        // Load the score using PlayerPrefs
        scoreRed = PlayerPrefs.GetInt(SCORE_KEY, 0);
        scoreRedText.text = scoreRed.ToString();
        //reset score
        PlayerPrefs.DeleteKey(SCORE_KEY);
        
        
        
    }
}
