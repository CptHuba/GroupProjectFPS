using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorApproachController : MonoBehaviour {

    public GameObject character;
    public float distance = 10f;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private Vector2 xz(Vector3 v) {
        return new Vector2(v.x, v.z);
    }

    // Update is called once per frame
    void Update() {
        Vector3 playerPos = character.transform.position;
        Vector3 doorPos = transform.position;

        if (Vector2.Distance(xz(playerPos), xz(doorPos)) < distance && playerPos.y > doorPos.y && playerPos.y < doorPos.y + 3) {
            animator.SetBool("character_nearby", true);
        }
        else {
            animator.SetBool("character_nearby", false);
        }
    }
}