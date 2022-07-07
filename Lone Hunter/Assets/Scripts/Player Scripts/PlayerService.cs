using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : GenericMonoSingleton<PlayerService>
{
    [SerializeField] private PlayerView playerView;
    [SerializeField] private PlayerSO playerSO;
    public PlayerController Activeplayer;

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        PlayerModel playerModel = new PlayerModel(playerSO);
        PlayerController playerController = new PlayerController(playerView, playerModel);
    }
}
