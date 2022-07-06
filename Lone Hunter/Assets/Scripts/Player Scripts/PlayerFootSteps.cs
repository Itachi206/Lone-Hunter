using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    private AudioSource footstep_Sound;
    [SerializeField] private AudioClip[] footstep_clip;
    private CharacterController character_controller;
    [HideInInspector]private float volume_min, volume_max;
    private float accumalated_Distance;
    [HideInInspector] public float step_Distance;

    void Awake()
    {
        footstep_Sound = GetComponent<AudioSource>();
        character_controller = GetComponentInParent<CharacterController>();
    }

    void Update()
    {
        CheckToPlayFootstepSound();
    }

    private void CheckToPlayFootstepSound()
    {
        if (!character_controller.isGrounded)
            return;


    }
}
