using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   public void LevelPowerUp()
    {
        if(SceneManager.GetActiveScene().name=="Game")
        {
            GameManager.levelPU = true;
        }
    }

    public void LevelPoison()
    {
        if (SceneManager.GetActiveScene().name == "Game_Poision")
        {
            GameManager.levelPois = true;
        }
    }
}
