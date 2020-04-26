using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rupee : MonoBehaviour
{
    public LayerMask Player;
    private SoundManager _soundManager;
    private void Start()
    {
        GameObject Soundmanager = GameObject.Find("SoundManager");
        _soundManager = Soundmanager.GetComponent<SoundManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(9))
        {
            PlayerLogic player = other.gameObject.GetComponent<PlayerLogic>();
            player.GainRupee();
            _soundManager.PlayRupeeSound();
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.Rotate(0, 0, -1f);
    }
}
