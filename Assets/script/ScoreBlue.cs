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
    private const string SCORE_KEY = "scoreBlue";

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("blueteam"))
        {
            scoreBlue++;
            scoreBlueText.text = scoreBlue.ToString();
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

    private void Start()
    {
        // Load the score from PlayerPrefs
        scoreBlue = PlayerPrefs.GetInt(SCORE_KEY, 0);
        scoreBlueText.text = scoreBlue.ToString();
    }
}


