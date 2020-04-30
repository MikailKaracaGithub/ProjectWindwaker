using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBombs : MonoBehaviour
{
    private Vector3 _holdingOffset;
    public GameObject Bomb;
    GameObject dest;
    GameObject bombInstance;
    bool holding = false;
    bool currentHolding = false;

    public PlayerLogic Player;

    private int _bombCount;
    void Start()
    {
        dest = GameObject.Find("Destination").gameObject;
    }

    void Update()
    {
        _bombCount = Player.ReturnBombCount();


        _holdingOffset = dest.transform.position;

        if (Input.GetKeyDown(KeyCode.Q) && _bombCount > 0 || Input.GetButtonDown("Bomb") && _bombCount > 0)
        {
            
            if (holding == false)
            {
                bombInstance = Instantiate(Bomb, _holdingOffset, Quaternion.identity);
                bombInstance.GetComponent<SphereCollider>().enabled = false;
                Rigidbody heldRB = bombInstance.GetComponent<Rigidbody>();
                heldRB.useGravity = false;
                heldRB.isKinematic = true;
                holding = true;

            }
            else
            {
                bombInstance.GetComponent<SphereCollider>().enabled = true;
                Rigidbody heldRB = bombInstance.GetComponent<Rigidbody>();
                heldRB.useGravity = true;
                heldRB.isKinematic = false;
                heldRB.AddForce(transform.forward * 500f);
                holding = false;
                bombInstance = null;
                Player.UseBomb();
            }
            
        }
        if (bombInstance != null)
        {
            bombInstance.transform.position = _holdingOffset;
            bombInstance.transform.rotation = transform.rotation;
        }
    }
}

