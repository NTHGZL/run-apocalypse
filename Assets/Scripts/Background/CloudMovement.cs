using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float startPositionX = 9.5f;
    public float maxPositionX = -9.5f;
    public float positionY;
    public float speed;
    void Start()
    {
        speed = Random.Range(0.1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= maxPositionX)
        {
            Debug.Log("OKOKOK");
            positionY = Random.Range(0, 4);
            transform.position = new Vector3(startPositionX, positionY);
            speed = Random.Range(0.1f, 2f);
        }
        transform.Translate(Vector3.left*speed*Time.deltaTime);
        
    }
}
