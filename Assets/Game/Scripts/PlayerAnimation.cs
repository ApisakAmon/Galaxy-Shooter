using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator Animator;
    private Player Player;
    void Start()
    {
        Animator = GetComponent<Animator>();
        Player = GetComponent<Player>();
    }

    void Update()
    {
        if (Player.isPlayerOne == true)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Animator.SetBool("TurnLeft", true);
                Animator.SetBool("TurnRight", false);
            }

            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Animator.SetBool("TurnLeft", false);
                Animator.SetBool("TurnRight", false);
            }

            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Animator.SetBool("TurnRight", true);
                Animator.SetBool("TurnLeft", false);
            }

            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                Animator.SetBool("TurnRight", false);
                Animator.SetBool("TurnLeft", false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                Animator.SetBool("TurnLeft", true);
                Animator.SetBool("TurnRight", false);
            }

            else if (Input.GetKeyUp(KeyCode.Keypad4))
            {
                Animator.SetBool("TurnLeft", false);
                Animator.SetBool("TurnRight", false);
            }

            else if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                Animator.SetBool("TurnRight", true);
                Animator.SetBool("TurnLeft", false);
            }

            if (Input.GetKeyUp(KeyCode.Keypad6))
            {
                Animator.SetBool("TurnRight", false);
                Animator.SetBool("TurnLeft", false);
            }
        }

    }
}
