using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button howToPlayButton;
    [SerializeField] private Button quitButton;
    
    [SerializeField] private Button quitHowToPlayPanelButton;

    [SerializeField] private GameObject howToPlayPanel;
    [SerializeField] private GameObject chooseLevel;
  
    private void Awake()
    {
        playButton.onClick.AddListener(ShowLevels);
        howToPlayButton.onClick.AddListener(ShowHowToPlayPanel);
        quitButton.onClick.AddListener(Application.Quit);
        
        quitHowToPlayPanelButton.onClick.AddListener(HideHowToPlayPanel);
        
        HideHowToPlayPanel();
        
        SoundManager.CreateSoundManagerGameObject();
    }

    private void ShowHowToPlayPanel()
    {
        howToPlayPanel.SetActive(true);
    }
    
    private void HideHowToPlayPanel()
    {
        howToPlayPanel.SetActive(false);
    }

    void ShowLevels()
    {
        chooseLevel.SetActive(true);
    }

    void HideLevels()
    {
        chooseLevel.SetActive(false);
    }
    
    public void LoadSceneGame(string Game)
    {
        SceneManager.LoadScene(Game);
    }
   
}
