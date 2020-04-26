using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainHeart : MonoBehaviour
{
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
            PlayerLogic player = other.GetComponent<PlayerLogic>();
            _soundManager.PlayHearContainerSound();
            player.GainHeart();
            Destroy(gameObject);

        }
    }
    private void Update()
    {
        transform.Rotate(0, 0, -1f);
    }
}
