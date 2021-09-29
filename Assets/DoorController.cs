using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class DoorController : MonoBehaviour {

    //public float distance = 10f;
    private Animator animator;
    bool trigger = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () 
    {
        if (trigger == true)
        {
            animator.SetBool("character_nearby", true);
        }
        else
        {
            animator.SetBool("character_nearby", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
            trigger = true;  
    }

    void OnTriggerExit(Collider other)
    {
            trigger = false;
    }
}