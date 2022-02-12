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
        if (gameObject.transform.position.x <= maxPositionX)
        {
            transform.position = new Vector3(startPositionX, positionY);
        }
        transform.Translate(Vector3.left*GameplayManager.Instance.speed*Time.deltaTime);
    }
}
