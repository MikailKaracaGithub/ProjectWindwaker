using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private GameObject _sword;
    private GameObject _shield;
    private GameObject _bow;

    private Animator _animator;

    public GameObject Arrow;

    private bool _hasBow;

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

            if (_hasBow == false)
            {
                _sword.SetActive(false);
                _shield.SetActive(false);
                _bow.SetActive(true);
                _animator.SetBool("IsShooting", true);
                _hasBow = true;

            }
            else
            {
                _animator.SetBool("IsReleased", true);

                Instantiate(Arrow, _bow.transform.position, gameObject.transform.rotation);

                ResetShootAnims();
                _hasBow = false;
            }

        }

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
