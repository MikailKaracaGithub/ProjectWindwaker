using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip Rupee;
    public AudioClip HeartContainer;

    public AudioClip[] LinkSwordNoises;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayRupeeSound()
    {
        if (Rupee)
        {
            _audioSource.PlayOneShot(Rupee);
        }
    }
    public void PlayHearContainerSound()
    {
        if (HeartContainer)
        {
            _audioSource.PlayOneShot(HeartContainer);
        }
    }
    public void PlayAttack()
    {
        int randomNum = Random.Range(0, 3);
        _audioSource.PlayOneShot(LinkSwordNoises[randomNum]);
    }

}
