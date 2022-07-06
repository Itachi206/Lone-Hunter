using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public Vector3 move_direction;
    public float move_Speed = 4f;
    public float player_Speed = 4f;
    public float gravity = 20f;
    public float jump_Force = 10f;
    public float vertical_Velocity;

    public float sprint_Speed = 8f;
    public float crouch_Speed = 1.5f;

    public float stand_Height = 1.6f;
    public float crouch_Height = 1f;

    public bool is_Crouching;    
    
    //attack Parameters
    public float fireRate = 15f;
    public float nextTimeToFire;
    public float damage = 20f;

    public bool is_Zoomed;
    public bool is_Aiming;  
    
    public PlayerModel(PlayerSO _playerSO)
    {
        move_Speed = _playerSO.move_Speed;
        player_Speed = _playerSO.player_Speed;
        gravity = _playerSO.gravity;
        jump_Force = _playerSO.jump_Force;

        crouch_Speed = _playerSO.crouch_Speed;
        stand_Height = _playerSO.stand_Height;
        crouch_Height = _playerSO.crouch_Height;    
        sprint_Speed = _playerSO.sprint_Speed;    
    
        fireRate = _playerSO.fireRate;        
        damage = _playerSO.damage;    
}

}
