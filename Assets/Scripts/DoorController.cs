using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] GameObject openDoor;
    private Animator animator;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip doorSound;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;
        animator = GetComponent<Animator>();
        animator.SetFloat("appearanceSpeed", 0.5f);
        
        if (_audioSource.loop)
        {
            StartCoroutine(PlayDoorSound());
        }
    }

    // Keeps looping the doorSound
    private IEnumerator PlayDoorSound()
    {
        while (_audioSource.loop)
        {
            _audioSource.PlayOneShot(doorSound);
            yield return new WaitForSeconds(doorSound.length);
        }
    }
    
    public void OpenDoor()
    {
        Animator openDoorAnimator = openDoor.GetComponent<Animator>();
        GameObject openedDoor = Instantiate(openDoor, transform.position, Quaternion.identity);
        Destroy(openedDoor, openDoorAnimator.runtimeAnimatorController.animationClips[0].length);
        _audioSource.loop = false;
    }
}
