using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5.0f;
    public float rotationSpeed = 50.0f;

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        float zDir = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(xDir, 0f, zDir);

        //if (Input.GetKey("q"))
        //{
        //    transform.Rotate(0.0f, Time.deltaTime * -1.0f * rotationSpeed, 0.0f);
        //}
        //else if (Input.GetKey("e"))
        //{
        //    transform.Rotate(0.0f, Time.deltaTime * rotationSpeed, 0.0f);

        //}
        if (moveDir.magnitude >= 0.1f)
        {
            controller.Move(moveDir * speed * Time.deltaTime);
        }
    }
}
