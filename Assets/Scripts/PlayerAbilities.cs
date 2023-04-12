using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    // Invisibility Variables and References
    Renderer playerRenderer;
    EnemyAI enemyScript;
    public Material invisibleMaterial;
    public Material normalMaterial;

    // EMP & Gravity Variables and References
    public float grenadeThrowForce = 5f;
    public GameObject empPrefab;


    void Awake()
    {
        // Invisibility Cache
        playerRenderer = GameObject.Find("Character").GetComponent<MeshRenderer>();
        enemyScript = GameObject.Find("Enemy").GetComponent<EnemyAI>();
    }



    // EMP MGMT
    public void ThrowEMPGrenade()
    {
        GameObject grenade = Instantiate(empPrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * grenadeThrowForce);
    }


    // Invisibility MGMT
    public void TriggerInvisibility()
    {
        StartCoroutine(InvisibilityTimer(3f));
    }

   
    public IEnumerator InvisibilityTimer(float duration)
    {

        playerRenderer.material = invisibleMaterial;
        enemyScript.playerInvisible = true;

        yield return new WaitForSeconds(duration);

        playerRenderer.material = normalMaterial;
        enemyScript.playerInvisible = false;
    }

    
}
