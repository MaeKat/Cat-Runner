﻿using System.Collections;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private float animationDuration = 3.0f;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isDead)
            return;

        if (Time.time < animationDuration) {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;

        if (controller.isGrounded) {
            verticalVelocity = -0.5f;
        }
        else
        {

            verticalVelocity -= gravity * Time.deltaTime;
        }

        //x left and right
        moveVector.x = Input.GetAxisRaw("Horizontal")* speed;

        //y up and down
        moveVector.y = verticalVelocity;

        //z move
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }
    public void SetSpeed(int modifier) {
        speed = 5.0f + modifier;
    }
    //called when hit an object
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.point.z > (transform.position.z + controller.radius/2)) {
            Death();
        }

    }
    private void Death() {
        Debug.Log("Dead");
        isDead = true;
        GetComponent<score>().OnDeath();
    }
}
