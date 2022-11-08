using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] float hitboxSize;


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        Collider[] PlayerHitbox = Physics.OverlapSphere(
            transform.position,
            hitboxSize,
            1 << LayerMask.NameToLayer("Interactible")
            );

        foreach (Collider colliderC in PlayerHitbox) //when a coin is collected
        {
            // Debug.Log("Collider hit");
            switch (colliderC.tag)
            { 
                case "Collectible - Coin":
                    //Collecting bonuses? IDK
                    break;
                case "Hazard":
                    //StartCoroutine(Gameplay.InGameDeath());
                    //place what happens to the player
                    break;
            }
               
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(
            transform.position,
            hitboxSize
            );

    }
}
