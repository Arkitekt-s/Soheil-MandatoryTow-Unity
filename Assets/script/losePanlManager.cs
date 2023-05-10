using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class losePanlManager : MonoBehaviour
{
   public static bool GameIsPaused = false;
   public GameObject losepanel;
   //public GameObject gameoverpanel;
   public Canvas canvas;
   bool menuPressed = false;
   public AudioSource audioSource;
   //game over
   public static bool isGameOver = false;
   
   public void Level1()
   {
      SceneManager.LoadScene("level1");
      //run unity game after click button
      Time.timeScale = 1f;
      GameIsPaused = false;
   }
   
   public void Quit()
   {
      Debug.Log("Quitting application.");
      UnityEditor.EditorApplication.isPlaying = false;
      Application.Quit();
   }
   //level 2
   public void Level2()
   {
      SceneManager.LoadScene("level2");
      Time.timeScale = 1f;
      GameIsPaused = false;
   }
   public void Level3()
   {
      SceneManager.LoadScene("level3");
      Time.timeScale = 1f;
      GameIsPaused = false;
   }
  
   
   
   void Pause()
   {
      showLosePanel();
      Time.timeScale = 0f; // stop time
      GameIsPaused = true;
   }

   /*void Gameover()
   {
      showGameoverPanel();
      Time.timeScale = 0f; // stop time
      GameIsPaused = true;
   }*/
   
   public void showLosePanel()
   
   {
      
      losepanel = Instantiate(losepanel);
      losepanel.SetActive(true);
      losepanel.AddComponent<CanvasRenderer>();
      losepanel.transform.SetParent(canvas.transform, false);
   }
   /*public void showGameoverPanel()
   {
      gameoverpanel = Instantiate(gameoverpanel);
      gameoverpanel.SetActive(true);
      gameoverpanel.AddComponent<CanvasRenderer>();
      gameoverpanel.transform.SetParent(canvas.transform, false);
      
      
   }*/

   
   void Resume()
   {
      Time.timeScale = 1f; // start time
      GameIsPaused = false;

   }
  

   
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         menuPressed = !menuPressed;

         if (menuPressed)
         {
            Pause();
            audioSource.Pause();
         }
         else
         {
            Resume();
            menuPressed = false;
            losepanel.SetActive(false);
            audioSource.Play();
            
         }
      }
      //if football game object going outside of peach then game over or out of the Ground
      /*if (GameObject.Find("Football").transform.position.y < -5|| GameObject.Find("Football").transform.position.y > 5
          || GameObject.Find("Football").transform.position.x < -24|| GameObject.Find("Football").transform.position.x > 24
            || GameObject.Find("Football").transform.position.z < -24|| GameObject.Find("Football").transform.position.z > 24)

      {
         menuPressed = !menuPressed;
            isGameOver = true;
            Gameover();
            audioSource.Play();
            gameoverpanel.SetActive(true);
            

      }*/
      
   }

}
