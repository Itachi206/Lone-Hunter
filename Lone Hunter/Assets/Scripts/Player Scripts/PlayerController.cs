using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    public PlayerView playerView;
    public PlayerModel playerModel;

    public PlayerController(PlayerView _playerView, PlayerModel _playerModel)
    {
        playerModel = _playerModel;
        playerView = GameObject.Instantiate<PlayerView>(_playerView);

        playerView.PlayerController = this;
    }

    public void PlayerMovement()
    {
        playerModel.move_direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));
        playerModel.move_direction = playerView.transform.TransformDirection(playerModel.move_direction);
        playerModel.move_direction *= playerModel.player_Speed * Time.deltaTime;
        ApplyGravity();
        playerView.character_Controller.Move(playerModel.move_direction);
    }

    public void ApplyGravity()
    {
        playerModel.vertical_Velocity -= playerModel.gravity * Time.deltaTime;
        PlayerJump();
        playerModel.move_direction.y = playerModel.vertical_Velocity * Time.deltaTime;
    }
      
    private void PlayerJump()
    {
        if(playerView.character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerModel.vertical_Velocity = playerModel.jump_Force;
        }
    }

    public void PlayerSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !playerModel.is_Crouching)
        {
            playerModel.player_Speed = playerModel.sprint_Speed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !playerModel.is_Crouching)
        {
            playerModel.player_Speed = playerModel.move_Speed;
        }
    }

    public void PlayerCrouch()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(playerModel.is_Crouching)
            {
                playerView.look_Root.localPosition = new Vector3(0f, playerModel.stand_Height, 0f);
                playerModel.player_Speed = playerModel.move_Speed;
                playerModel.is_Crouching = false;
            }
            else
            {
                playerView.look_Root.localPosition = new Vector3(0f, playerModel.crouch_Height, 0f);
                playerModel.player_Speed = playerModel.crouch_Speed;
                playerModel.is_Crouching = true;
            }
        }
    }
}
