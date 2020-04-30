using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public GameObject drop;
    public Transform Spawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(11))
        {
            
            Instantiate(drop,Spawn.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
