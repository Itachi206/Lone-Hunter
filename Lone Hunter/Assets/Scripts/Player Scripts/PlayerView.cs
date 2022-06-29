using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public PlayerController PlayerController;
    [HideInInspector] public CharacterController character_Controller;
    [HideInInspector] public Transform look_Root;
    

    private void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
        look_Root = transform.GetChild(0);
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        PlayerController.PlayerMovement();
        PlayerController.PlayerSprint();
        PlayerController.PlayerCrouch();
    }
}
