using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    
    public float startPositionX = 40f;
    public float maxPositionX = -25f;

    public const float positionY = -4.543f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Replace the "ground" element after it has passed on the other side of the camera,
        // which gives the impression of an infinite ground
        if (gameObject.transform.position.x <= maxPositionX)
        {
            transform.position = new Vector3(startPositionX, positionY);
        }
        transform.Translate(Vector3.left*GameplayManager.Instance.speed*Time.deltaTime);
    }
}
