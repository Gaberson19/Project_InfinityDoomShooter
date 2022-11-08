using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    CharacterController playerController;

    [SerializeField] bool isGrounded;
    float groundedRaycastSize;
    float groundedRaycastPosition;

    [SerializeField] bool onCeiling;
    float ceilingRaycastSize;
    float ceilingRaycastPosition;

    bool isJumpPressed;
    float GRAVITYVALUE;
    [SerializeField] float jumpHeight;
    [SerializeField] float jumpGravity;


    [SerializeField] Vector3 velocity;
    [SerializeField] Vector3 playerVelocity;

    void Start()
    {
        groundedRaycastSize = 0.9f;
        groundedRaycastPosition = 1f;
        ceilingRaycastSize = 0.9f;
        ceilingRaycastPosition = 1f;

        GRAVITYVALUE = -9.817f;
        jumpGravity = 0.0f;
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GravityAction();
        PlayerOnJump();

    }

    //Jumping
    void GravityAction()
    {
        //setting Raycasts if player is on the ground
        isGrounded = Physics.OverlapBox(
            transform.position + (Vector3.down * groundedRaycastPosition),
            Vector3.one - (((Vector3.right + Vector3.forward) * 0.5f) + (Vector3.up * groundedRaycastSize)),
            Quaternion.identity,
            1 << LayerMask.NameToLayer("Level Ground")
            ).Length > 0;

        //setting Raycasts if player is on the ceiling
        onCeiling = Physics.OverlapBox(
            transform.position + (Vector3.up * ceilingRaycastPosition),
            Vector3.one - (((Vector3.right + Vector3.forward) * 0.5f) + (Vector3.up * ceilingRaycastSize)),
            Quaternion.identity,
            1 << LayerMask.NameToLayer("Level Ground")
            ).Length > 0;

        if (isGrounded)
        {
            playerVelocity.y = 0.0f;
        }
         
        if (isJumpPressed && isGrounded)
        {
            jumpGravity = GRAVITYVALUE;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -1.0f * GRAVITYVALUE);
            isJumpPressed = false;
        } else
        {
            jumpGravity = 0;
        }

        if (onCeiling)
        {
            playerVelocity.y = -playerVelocity.y / 2;
        }


       
        playerVelocity.y += (GRAVITYVALUE + jumpGravity) * Time.deltaTime;
        playerController.Move(playerVelocity * Time.deltaTime);
    }

    void PlayerOnJump()
    {
        // Debug.Log("JUMP");
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                isJumpPressed = true;
                isGrounded = true;
            }
        }
        else
        {
            isJumpPressed = false;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            transform.position + Vector3.down * groundedRaycastPosition,
            Vector3.one - (((Vector3.right + Vector3.forward) * 0.5f) + (Vector3.up * groundedRaycastSize))
            );

        Gizmos.DrawWireCube(
            transform.position + (Vector3.up * ceilingRaycastPosition),
            Vector3.one - (((Vector3.right + Vector3.forward) * 0.5f) + (Vector3.up * ceilingRaycastSize))
            );
    }
}
