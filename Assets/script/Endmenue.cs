using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endmenue : MonoBehaviour
{
    // end game
    public void endGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    
}
