using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(9))
        {
            PlayerLogic player = other.gameObject.GetComponent<PlayerLogic>();
            player.GainHealth();
            Destroy(gameObject);
        }
    }
}
