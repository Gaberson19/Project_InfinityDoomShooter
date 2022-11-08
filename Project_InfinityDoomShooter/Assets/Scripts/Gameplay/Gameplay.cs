using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    public static Gameplay Instance { get; private set; }
    int collectibleValue;
    static bool playerDead;
    [SerializeField] GameObject player;

    public delegate void playerActions();
    public static playerActions PlayerController;

    //Singleton instancing
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

    //start
    void Start()
    {
        playerDead = false;

    }

    void Update()
    {
        if (Gameplay.PlayerController != null)
        {
            Gameplay.PlayerController.Invoke();
        }
        else
        {
            Debug.Log("PlayerController is Null");
        }

    }

    public void CollectCoin()
    {
        //keeps track of coins
        collectibleValue--;
        UI.Instance.RefreshCollectibleText(collectibleValue);

        //win
        if(collectibleValue <= 0)
        {
            UI.Instance.VictoryScreen();
            player.GetComponent<PlayerMovement>().PlayerControllerWin();
        }
    }

    public static IEnumerator InGameDeath()
    {
        if(playerDead == false)
        {
            playerDead = true;
            UI.Instance.DeathScreen();
            yield return new WaitForSeconds(1f);
            UI.Instance.RestartScreen();
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        

    }

    public static IEnumerator InGameRestart()
    {
        UI.Instance.RestartScreen();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public static IEnumerator InGameDQuit()
    {
        UI.Instance.DeathScreen();
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }


}
