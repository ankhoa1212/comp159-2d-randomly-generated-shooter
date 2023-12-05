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
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("appearanceSpeed", 0.5f);
    }

    public void OpenDoor()
    {
        Animator openDoorAnimator = openDoor.GetComponent<Animator>();
        GameObject openedDoor = Instantiate(openDoor, transform.position, Quaternion.identity);
        Destroy(openedDoor, openDoorAnimator.runtimeAnimatorController.animationClips[0].length);
    }
}
