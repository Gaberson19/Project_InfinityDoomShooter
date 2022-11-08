using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMenu : MonoBehaviour
{
    //Add and remove functions to controller delegate

    [SerializeField] GameObject pauseMenuMain;
    [SerializeField] GameObject[] menuPhase;
    [SerializeField] int currentMenuPhase;
    [SerializeField] int currentLevel;
    [SerializeField] Scene[] levelList;


    private void Start()
    {
        currentMenuPhase = 0;
        
    }

    public void ShowMenu()
    {
        pauseMenuMain.SetActive(true);
    }

    public void HideMenu()
    {
        pauseMenuMain.SetActive(false);
    }

    public void MoveToMenu(int phase)
    {
        menuPhase[currentMenuPhase].SetActive(false);
        
        currentMenuPhase = phase;
        menuPhase[currentMenuPhase].SetActive(true);
    }

    public void ReturnTo00MainPauseMenu()
    {
        menuPhase[currentMenuPhase].SetActive(false);
        menuPhase[0].SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        menuPhase[currentMenuPhase].SetActive(false);
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Scenes/Level" + level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
