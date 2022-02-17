using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    public bool canJump = true;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Debug.Log("JE SAUTE !");
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*700);
            //gameObject.transform.Translate(Vector3.up*GameplayManager.Instance.speed*5*Time.deltaTime);
        }
    }
}
