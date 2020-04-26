using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePadTesting : MonoBehaviour
{
    private PlayerLogic _player;
    private bool _inside = false;
    [SerializeField]
    private float _timeLeft = 2f;
    private float _Resettime;
    private void Start()
    {
        _Resettime = _timeLeft;
    }
    private void Update()
    {
       
            _timeLeft -= Time.deltaTime;
            if (_timeLeft < 0 && _inside == true)
            {
                _player.ApplyDamage();
                _timeLeft = _Resettime;
            }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {

            _player = other.gameObject.GetComponent<PlayerLogic>();
            _inside = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        _inside = false;
    }
}
