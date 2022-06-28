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
        playerModel.move_direction *= playerModel.move_Speed * Time.deltaTime;
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
}
