using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    void Update()
    {
        Vector3 movement = transform.forward;
        transform.position += movement * _speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(8))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
