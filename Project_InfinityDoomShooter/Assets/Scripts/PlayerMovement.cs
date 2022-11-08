using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    CharacterController controller;
    [SerializeField] GameObject playerMenu;

    //General Player Variables
    [SerializeField] float mouseSensitivity;
    [SerializeField] float tiltAngle;
    [SerializeField] GameObject playerCamera;

   
    
    bool isPaused;

    void Start()
    {
        playerMenu.GetComponent<PlayerMenu>().HideMenu();
        isPaused = false;

        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        PlayerControllerStart();
    }

    //tenor

    public void PlayerControllerStart()
    {
        Gameplay.PlayerController = null;

        Gameplay.PlayerController += PlayerRotateCamera;
        Gameplay.PlayerController += PlayerPressRestart;
        Gameplay.PlayerController += PlayerPressCancel;
    }

    public void PlayerControllerPause()
    {
        Gameplay.PlayerController -= PlayerRotateCamera;
    }

    public void PlayerControllerWin()
    {
        Gameplay.PlayerController += PlayerWinControlls;

        Gameplay.PlayerController -= PlayerRotateCamera;
       // Gameplay.PlayerController -= PlayerGravity;
        Gameplay.PlayerController -= PlayerPressCancel;
    }


    public void PlayerControllerResume()
    {
        Gameplay.PlayerController += PlayerRotateCamera;
    }

    public void PlayerControllerStop()
    {
        Gameplay.PlayerController = null;
    }


    void PlayerRotateCamera()
    {
        
        if(gameObject != null)
        {
            //note to self, look up about euler angles
            tiltAngle -= Input.GetAxis("Mouse Y");

            tiltAngle = Mathf.Clamp(tiltAngle, -90f, 90f);
            playerCamera.transform.localRotation = Quaternion.Euler(tiltAngle + Time.deltaTime + mouseSensitivity, 0, 0);

            float mouseX = mouseSensitivity * Time.deltaTime * Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up * mouseX);
        }
        
    }

    void PlayerPressRestart()
    {
        if (Input.GetButton("Restart"))
        {
            playerMenu.GetComponent<PlayerMenu>().HideMenu();
            StartCoroutine(Gameplay.InGameRestart());
        }
    }

    void PlayerPressCancel()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(isPaused == false)
            {
                Debug.Log("Paused");
                isPaused = true;
                PlayerControllerPause();
                playerMenu.GetComponent<PlayerMenu>().ShowMenu();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                Debug.Log("Resumed");
                isPaused = false;
                PlayerControllerResume();
                playerMenu.GetComponent<PlayerMenu>().HideMenu();
                playerMenu.GetComponent<PlayerMenu>().MoveToMenu(0);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

            }
        } 
    }


    void PlayerWinControlls()
    {
        // Debug.Log("JUMP");
        if (Input.GetButtonDown("Jump"))
        {
            //Move to next level
        } else if (Input.GetButtonDown("Cancel"))
        {
            Cursor.lockState = CursorLockMode.None;
            playerMenu.GetComponent<PlayerMenu>().ReturnToMainMenu();
        }

    }


}
