using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private GameObject _sword;
    private GameObject _shield;
    private GameObject _bow;

    private Animator _animator;
    public bool _isShooting = false;

    public GameObject Arrow;

    void Start()
    {
        _animator = GetComponent<Animator>();

        _sword = GameObject.Find("Sword");
        _shield = GameObject.Find("Shield");
        _bow = GameObject.Find("Bow");
        _bow.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShootArrow();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            Shoot();
        }
      
    }

    private void ShootArrow()
    {
        _sword.SetActive(false);
        _shield.SetActive(false);
        _bow.SetActive(true);
        _isShooting = true;
        _animator.SetBool("IsShooting", true);


    }
    private void Shoot()
    {
        _animator.SetBool("IsReleased", true);

        Instantiate(Arrow, _bow.transform.position, gameObject.transform.rotation);
        _isShooting = false;

        Invoke("ResetShootAnims", 1.5f);


    }
    private void ResetShootAnims()
    {
        _sword.SetActive(true);
        _shield.SetActive(true);
        _bow.SetActive(false);
        _animator.SetBool("IsShooting", false);
        _animator.SetBool("IsReleased", false);
    }
}
