using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabLogic : MonoBehaviour
{
    public float GrabbingDistance = 2;
    public float FeetOffset = 1;
    public LayerMask GrabbingMask;

    private Vector3 _holdingOffset;
    public GameObject Holding;
    // remove this later on when put into playerscript
    private PlayerLogic _player;
    private bool _cuccoFlight = false;
    private void Start()
    {
        _holdingOffset = GameObject.Find("Destination").gameObject.transform.position;
        // remove this lateron when put in player script
        GameObject lonk = GameObject.Find("Lonk");
        _player = lonk.GetComponent<PlayerLogic>();

    }
    void Update()
    {
        Debug.DrawRay(transform.position - Vector3.down * FeetOffset, transform.forward * GrabbingDistance);

        
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            if (Holding == null && Physics.Raycast(transform.position - Vector3.down * FeetOffset, transform.forward, out hit, GrabbingDistance, GrabbingMask))
            {
                if (hit.transform.gameObject.name == "CuccoFly")
                {
                    _cuccoFlight = true;
                    //enable in playerscript the cuccoo flight
                    _player.CuccooSwitch();
                }

                Holding = hit.collider.gameObject;
                Holding.GetComponent<BoxCollider>().enabled = false;
                Rigidbody heldRB = Holding.GetComponent<Rigidbody>();
                heldRB.useGravity = false;
                heldRB.isKinematic = true;
            }
            else
            {
                if (Holding != null) 
                {
                    if (_cuccoFlight = true)
                    {
                        _player.CuccooSwitchOff();
                    }
                    Holding.GetComponent<BoxCollider>().enabled = true;
                    Rigidbody heldRB = Holding.GetComponent<Rigidbody>();
                    heldRB.useGravity = true;
                    heldRB.isKinematic = false;
                    heldRB.AddForce(transform.forward * 500f);

                    _cuccoFlight = false;
                }
                Holding = null;
            }

            
        }

        if (Holding != null)
        {
            Holding.transform.position = transform.position + Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.up) * _holdingOffset;
            Holding.transform.rotation = transform.rotation;
        }
        
    }

}
