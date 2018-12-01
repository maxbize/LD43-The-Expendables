﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour {

    private Overlord overlord;
    private CharController charController;

    // Use this for initialization
    void Start() {
        charController = GetComponent<CharController>();
        overlord = FindObjectOfType<Overlord>();
    }

    void FixedUpdate() {
        if (overlord != null) {
            MoveTowardsOverlord();
        }
    }

    // Called every frame - command from the overlord where we should walk towards
    public void MoveTowardsOverlord() {
        Vector3 toPos = (overlord.transform.position - transform.position).normalized;
        toPos.y = 0;
        charController.HandleMovement(toPos);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.GetComponent<Overlord>() != null) {
            Kill();
        }
        Minion minion = collision.transform.GetComponent<Minion>();
        if (minion != null && minion.controlled) {
            Kill();
        }
    }

    public void Kill() {
        Destroy(gameObject);
    }
}