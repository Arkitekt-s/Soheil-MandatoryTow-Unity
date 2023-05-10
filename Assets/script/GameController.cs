using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Gameover gameover;
     int maxPlatform = 0;
    // Start is called before the first frame update
    public void GameOver()
    {
        gameover.Setup(maxPlatform);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
