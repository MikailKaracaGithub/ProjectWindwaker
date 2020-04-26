using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordLogic : MonoBehaviour
{
    public PlayerLogic _player;
    private void OnTriggerEnter(Collider other)
    {

        if (_player._isAttacking && other.gameObject.layer.Equals(8))
        {
            EnemyLogic enemy = other.GetComponent<EnemyLogic>();
            enemy.SelfDestruct();
        }
    }
}
