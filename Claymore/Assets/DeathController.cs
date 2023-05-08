using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    [SerializeField] Enemy enemyScript;
    [SerializeField] AttackSoundController attackSoundController;
    void Update()
    {
        if(enemyScript.isDead == true)
        {
            attackSoundController.DeathSound();
        }
    }
}
