using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public GameObject drop;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(11))
        {
            
            Instantiate(drop,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
