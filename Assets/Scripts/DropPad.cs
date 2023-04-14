using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPad : MonoBehaviour
{
    public Rigidbody rigidbody;
    private bool hasPlayerJumpedOn = false;

    void Start()
    {
        rigidbody.useGravity = false; // Disable gravity initially
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            hasPlayerJumpedOn = true;
            StartCoroutine(DropPlatform());
        }
    }

    IEnumerator DropPlatform()
    {
        yield return new WaitForSeconds(.25f); // Delay for one second
        rigidbody.useGravity = true; // Enable gravity after the delay
    }
}
