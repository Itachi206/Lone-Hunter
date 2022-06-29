using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : MonoBehaviour
{
    [SerializeField] public PlayerView playerView;

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        PlayerModel playerModel = new PlayerModel();
        PlayerController playerController = new PlayerController(playerView, playerModel);
    }
}
