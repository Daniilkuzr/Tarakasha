using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject menu;
    public GameObject OptionMenuPanel;
    public GameObject gameStopMenu;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OptionMenu()
    {
        OptionMenuPanel.SetActive(true);
        menu.SetActive(false);
    }

    public void ExitoptionMenu()
    {
        OptionMenuPanel.SetActive(false);
        menu.SetActive(true);
    }

    public void Pause()
    {
        gameStopMenu.SetActive(true);
        FindObjectOfType<GunConroller>().StopGame = false;
    }

    public void OnPause()
    {
        gameStopMenu.SetActive(false);
        FindObjectOfType<GunConroller>().StopGame = true;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

}
