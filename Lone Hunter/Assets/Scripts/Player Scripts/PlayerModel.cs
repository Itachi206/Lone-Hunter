using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    //health parameter
    public float health;

    //movement and jump parameters
    public Vector3 move_direction;
    public float move_Speed;
    public float player_Speed;
    public float gravity;
    public float jump_Force;
    public float vertical_Velocity;

    //crouch parameters
    public float crouch_Speed;
    public float stand_Height;
    public float crouch_Height;

    //sprint parameters
    public float sprint_Speed;
    public float sprint_Value;
    public float sprint_ThreShold;

    //attack Parameters
    public float fireRate;
    public float nextTimeToFire;
    public float damage;

    //bool parameters
    public bool is_Crouching;
    public bool IsDead;
    public bool is_Zoomed;
    public bool is_Aiming;  
    
    public PlayerModel(PlayerSO _playerSO)
    {
        health = _playerSO.health;

        move_Speed = _playerSO.move_Speed;
        player_Speed = _playerSO.player_Speed;
        gravity = _playerSO.gravity;
        jump_Force = _playerSO.jump_Force;

        crouch_Speed = _playerSO.crouch_Speed;
        stand_Height = _playerSO.stand_Height;
        crouch_Height = _playerSO.crouch_Height;
        
        sprint_Speed = _playerSO.sprint_Speed;
        sprint_Value = _playerSO.sprint_Value;
        sprint_ThreShold = _playerSO.sprint_ThreShold;

        fireRate = _playerSO.fireRate;        
        damage = _playerSO.damage;    
    }

}
