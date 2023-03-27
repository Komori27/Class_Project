using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] currentPosition;
    public int currentLevelIndex;

    public PlayerData(PlatformerPlayer player, int currentLevelIndex = 0)
    {
        currentPosition = new float[] { player.transform.position.x, player.transform.position.y };
        this.currentLevelIndex = currentLevelIndex;
    }
}

