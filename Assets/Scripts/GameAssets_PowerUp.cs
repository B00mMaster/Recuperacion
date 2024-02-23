using System;
using UnityEngine;

public class GameAssets_PowerUp : MonoBehaviour
{
   
   
    public static GameAssets_PowerUp Instance { get; private set; }

    
    public Sprite powerUpSprite;
    

   

    private void Awake()
    {
        // Singleton
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        Instance = this;
    }
}
