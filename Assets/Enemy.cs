﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int health = 100;
    public int bodyDamage = 100;

    public GameObject deathEffect;

    public void TakeDamage (int bulletDamage)
    {
        health = health - bulletDamage;

        if (health <= 0)
        {
            Die();
        }
    }
	
	void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        StartCoroutine(Break());
    
        // Destroy(gameObject);
    }
     private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamagePlayer(bodyDamage);
        }
        Destroy(gameObject);
    }

    private IEnumerator Break() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(2000);
    }
}