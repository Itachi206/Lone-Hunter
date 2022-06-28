using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public PlayerController PlayerController;
    [HideInInspector] public CharacterController character_Controller;
    

    private void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        PlayerController.PlayerMovement();
    }
}
