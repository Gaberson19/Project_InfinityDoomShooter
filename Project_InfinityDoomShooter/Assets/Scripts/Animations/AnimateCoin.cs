using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCoin : MonoBehaviour
{
    float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * 5);
    }
}
