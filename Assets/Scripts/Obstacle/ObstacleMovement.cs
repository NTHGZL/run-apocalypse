using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    
    
    void Start()
    {
        Destroy(gameObject, 19f/GameplayManager.Instance.speed);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.left*GameplayManager.Instance.speed*Time.deltaTime));
    }
}
