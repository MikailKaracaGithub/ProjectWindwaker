using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    
    [SerializeField]
    private float _radius = 4.0f;

    [SerializeField]
    private bool _isThrown;

    void FixedUpdate()
    {
        if (_isThrown == true)
        {
            Invoke("Detonate", 5f);
        }
    }
    private void Detonate()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, _radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(152, 11, 30, 0.4f);

        Gizmos.DrawSphere(gameObject.transform.position, _radius);
    }
}
