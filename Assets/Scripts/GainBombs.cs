using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainBombs : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(9))
        {
            PlayerLogic player = other.GetComponent<PlayerLogic>();
            player.GainBomb();
            Destroy(gameObject);

        }
    }
}
