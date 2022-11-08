using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOptions : MonoBehaviour
{
    public PlayerOptions Instance;

    public float volumeSFX;
    public float volumeBGM;
    public float mouseSensitivity;

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

    private void OnDestroy()
    {
        Instance = null;
    }


}
