using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public PlayerController PlayerController;
    [HideInInspector] public CharacterController character_Controller;
    [HideInInspector] public Transform look_Root;

    //attack
    internal Animator zoomCameraAnim;
    internal Camera mainCam;
    internal GameObject crosshair;
    public GameObject arrow_Prefab, spear_prefab;
    public Transform arrow_Bow_StartPosition;
    

    private void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
        look_Root = transform.GetChild(0);
        zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();
        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);
        mainCam = Camera.main;
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
        PlayerController.WeaponShoot();
        PlayerController.ZoomInAndOut();
    }

    internal GameObject InstantiateArrow()
    {
        return Instantiate(arrow_Prefab);
    }

    internal GameObject InstantiateSpear()
    {
        return Instantiate(spear_prefab);
    }
}
