using System;
using UnityEngine;

public class GameAssets_Pois : MonoBehaviour
{
    
   
    
    public static GameAssets_Pois Instance { get; private set; }

    
    
  
    public Sprite poisonFoodSprite1;
    public Sprite poisonFoodSprite2;

    

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
