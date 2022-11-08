using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] Vector3 collectorRaycastSize;



    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        Collider[] boxRay;
        boxRay = Physics.OverlapBox(
            transform.position,
            collectorRaycastSize,
            Quaternion.identity,
            1 << LayerMask.NameToLayer("Touch Triggerable")
            );

        foreach (Collider colliderC in boxRay) //when a coin is collected
        {
            // Debug.Log("Collider hit");
            switch (colliderC.tag)
            {
                case "Collectible - Coin":
                    Gameplay.Instance.CollectCoin();
                    Destroy(colliderC.gameObject);
                    break;
                case "Player Hurt":
                    StartCoroutine(Gameplay.InGameDeath());
                    break;
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(
            transform.position,
            collectorRaycastSize
            );

    }
}
