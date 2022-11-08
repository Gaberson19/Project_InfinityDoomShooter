using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }
    [SerializeField] TMPro.TextMeshProUGUI collectibleText;
    [SerializeField] CanvasGroup winScreen;
    [SerializeField] CanvasGroup startScreen;
    [SerializeField] CanvasGroup deathScreen;
    [SerializeField] CanvasGroup restartScreen;
    // Start is called before the first frame update


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void OnDestroy()
    {
        Instance = null;
    }

    void Start()
    {
        
        winScreen.alpha = 0;
        deathScreen.alpha = 0;
        restartScreen.alpha = 0;
        startScreen.alpha = 100;
    }

    public void RefreshCollectibleText(int value)
    {
        collectibleText.text = "Coins Left: " + value;
    }

    public void VictoryScreen()
    {
        Debug.Log("VICTORY SCREECH");
        //winScreen.enabled = true;
        LeanTween.alphaCanvas(winScreen, 100, 60f);
    }

    public void RestartScreen()
    {
        LeanTween.alphaCanvas(restartScreen, 100, 60f);
    }

    public void DeathScreen()
    {
        LeanTween.alphaCanvas(deathScreen, 100, 20f);
    }

    public void StartScreen()
    {
        LeanTween.alphaCanvas(startScreen, 0, 1f);
    }
}
