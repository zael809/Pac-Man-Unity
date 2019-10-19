using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.4f;
    private bool canMove = true;

    private const string GROUND_TAG = "Ground";

    void Update() 
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            //change direction to be left
            ChangeDirection(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //change direction to be right
            ChangeDirection(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //change direction to up
            ChangeDirection(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //change direction to be down
            ChangeDirection(Vector3.right);
        }
        
        if (!canMove)
        {
            return;
        }

        transform.position += speed * transform.forward;
    }


    private void ChangeDirection(Vector3 direction)
    {
        transform.forward = direction;
        canMove = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(GROUND_TAG))
            return;
        
        canMove = false;
    }
}
