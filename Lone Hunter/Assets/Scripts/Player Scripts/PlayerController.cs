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

    internal void WeaponShoot()
    {
        if(WeaponManager.Instance.GetCurrenSelectedWeapon().fireType == WeaponFireType.MULTIPLE)
        {
            if(Input.GetMouseButton(0) && Time.time > playerModel.nextTimeToFire)
            {
                playerModel.nextTimeToFire = Time.time + 1f / playerModel.fireRate;
                WeaponManager.Instance.GetCurrenSelectedWeapon().ShootAnimation();
                BulletFired();
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(WeaponManager.Instance.GetCurrenSelectedWeapon().tag == Tags.AXE_TAG)
                {
                    WeaponManager.Instance.GetCurrenSelectedWeapon().ShootAnimation();
                }

                if(WeaponManager.Instance.GetCurrenSelectedWeapon().bulletType == WeaponBulletType.BULLET)
                {
                    WeaponManager.Instance.GetCurrenSelectedWeapon().ShootAnimation();
                    BulletFired();
                }
                else
                {
                    if(playerModel.is_Aiming)
                    {
                        WeaponManager.Instance.GetCurrenSelectedWeapon().ShootAnimation();

                        if(WeaponManager.Instance.GetCurrenSelectedWeapon().bulletType == WeaponBulletType.ARROW)
                        {
                            ThrowArrowOrSpear(true);
                        }
                        else if(WeaponManager.Instance.GetCurrenSelectedWeapon().bulletType == WeaponBulletType.SPEAR)
                        {
                            ThrowArrowOrSpear(false);
                        }
                    }
                }
            }
        }
    }

    public void ZoomInAndOut()
    {
        if(WeaponManager.Instance.GetCurrenSelectedWeapon().weapon_Aim == WeaponAim.AIM)
        {
            if(Input.GetMouseButtonDown(1))
            {
                playerView.zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);
                playerView.crosshair.SetActive(false);
            }
            if (Input.GetMouseButtonUp(1))
            {
                playerView.zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);
                playerView.crosshair.SetActive(false);
            }
        }

        if (WeaponManager.Instance.GetCurrenSelectedWeapon().weapon_Aim == WeaponAim.SELF_AIM)
        {
            if(Input.GetMouseButtonDown(1))
            {
                WeaponManager.Instance.GetCurrenSelectedWeapon().Aim(true);
                playerModel.is_Aiming = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                WeaponManager.Instance.GetCurrenSelectedWeapon().Aim(false);
                playerModel.is_Aiming = false;
            }
        }
    }

    private void ThrowArrowOrSpear(bool throwArrow)
    {
        if(throwArrow)
        {
            GameObject arrow = playerView.InstantiateArrow();
            arrow.transform.position = playerView.arrow_Bow_StartPosition.position;
            arrow.GetComponent<ArrowBowScript>().Launch(playerView.mainCam);
        }
        else
        {
            GameObject spear = playerView.InstantiateSpear();
            spear.transform.position = playerView.arrow_Bow_StartPosition.position;
            spear.GetComponent<ArrowBowScript>().Launch(playerView.mainCam);
        }
    }

    private void BulletFired()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(playerView.mainCam.transform.position, playerView.mainCam.transform.forward, out hit))
        {

            Debug.Log("WE HIT " + hit.transform.gameObject.name);
            //if(hit.transform.tag == Tags.ENEMY_TAG)
            //{
            //    hit.transform.GetComponent<HealthScript>().applydamage(damage);
            //}
        }
    }
}
