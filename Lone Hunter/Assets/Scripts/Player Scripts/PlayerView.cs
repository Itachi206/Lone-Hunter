using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour, IDamagable
{
    public PlayerController PlayerController;
    [HideInInspector] public CharacterController character_Controller;
    [HideInInspector] public Transform look_Root;
    
    internal Animator zoomCameraAnim;
    internal Camera mainCam;
    //internal GameObject crosshair;
    public GameObject arrow_Prefab, spear_prefab;
    public Transform arrow_Bow_StartPosition;

    private GameObject health_Stats, stamina_Stats;

    public GameObject attack_Point;
    public LayerMask layerMask;
    public float damage = 2f;
    public float radius = 1f;

    private void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
        look_Root = transform.GetChild(0);
        zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();
        //crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);
        mainCam = Camera.main;
        health_Stats = GameObject.FindGameObjectWithTag(Tags.HEALTH_TAG);
        stamina_Stats = GameObject.FindGameObjectWithTag(Tags.STAMINA_TAG);
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

    public void ApplyDamage(float damage)
    {
        PlayerController.ApplyDamage(damage);
    }

    //public void Display_HealthStats(float healthValue)
    //{
    //    healthValue /= 100f;
    //    health_Stats.GetComponent<Image>().fillAmount = healthValue;
    //}

    //public void Display_StaminaStats(float staminaValue)
    //{
    //    staminaValue /= 100f;
    //    stamina_Stats.GetComponent<Image>().fillAmount = staminaValue;
    //}

    internal GameObject InstantiateArrow()
    {
        return Instantiate(arrow_Prefab);
    }

    internal GameObject InstantiateSpear()
    {
        return Instantiate(spear_prefab);
    }
}
