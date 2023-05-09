using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreBlue : MonoBehaviour
{
    public int scoreBlue = 0;
    public TextMeshProUGUI scoreBlueText;
    public AudioSource audioSource;
    public AudioClip goalSound;
    public TextMeshProUGUI goalTextB;
    private const string SCORE_KEY = "scoreBlue";

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("blueteam"))
        {
            scoreBlue++;
            scoreBlueText.text = scoreBlue.ToString();
            //HIDE THE TEXT THAND SHOW IT AGAIN AND HID IT AGAIN
            goalTextB.gameObject.SetActive(true);
            goalTextB.text = "GOAL!";

            StartCoroutine(HideGoalText());
            IEnumerator HideGoalText()
            {
                yield return new WaitForSeconds(5);
                goalTextB.gameObject.SetActive(false);
            }
            
            
            PlayerPrefs.SetInt(SCORE_KEY, scoreBlue);
            if (goalSound != null)
            {
                audioSource.PlayOneShot(goalSound);
            }
            else
            {
                Debug.LogWarning("No goal sound found!");
            }// Save the score to PlayerPrefs
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
        // Load the score from PlayerPrefs
        scoreBlue = PlayerPrefs.GetInt(SCORE_KEY, 0);
        scoreBlueText.text = scoreBlue.ToString();
        //reset score
        PlayerPrefs.DeleteKey(SCORE_KEY);
    }
}


