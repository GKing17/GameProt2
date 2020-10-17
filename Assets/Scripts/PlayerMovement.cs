using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    Vector3 moveVector,gravity;
    Animator anim;

    public float speed,
                 jumpSpeed;

    int laneNumber = 1,
        lanesCount = 2;

    public float firstLanePos,
                 laneDistance,
                 sideSpeed;
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        moveVector = new Vector3(1,0,0);
        gravity = Vector3.zero;
    }

    void Update()
    {
        if (cc.isGrounded)
        {
            gravity = Vector3.zero;
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                anim.SetTrigger("JumpTrigger");
                gravity.y = jumpSpeed;
            }
        }
        else
        {
            gravity += Physics.gravity * (Time.deltaTime * 3);
        }
        moveVector.x = speed;
        moveVector += gravity;
        moveVector *= Time.deltaTime;

        CheckInput();
        
        cc.Move(moveVector);
        Vector3 newPosition = transform.position;
        newPosition.z = Mathf.Lerp(newPosition.z, firstLanePos + (laneNumber * laneDistance), Time.deltaTime * sideSpeed);
        transform.position = newPosition;
    }

    void CheckInput()
    {
        int sign = 0;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sign = -1;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                sign = 1;
            }else
            {
                return;
            }
        }

        laneNumber += sign;
        laneNumber = Mathf.Clamp(laneNumber, 0, lanesCount);
    }
}
