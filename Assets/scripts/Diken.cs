using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diken : MonoBehaviour
{
    public int damageAmount = 10; // Dikenden alınacak hasar miktarı

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Karakterin sağlık sistemini kontrol eden script'i alalım.
            CharacterHealth characterHealth = other.GetComponent<CharacterHealth>();

            if (characterHealth != null)
            {
                // Diken çarptığında karakterin canını eksiltme fonksiyonunu çağır.
                characterHealth.TakeDamage(damageAmount);
            }

            
        }
    }
}