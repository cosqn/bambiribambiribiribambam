using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage = 10; // Ok hasar değeri

    // Karakterle temas edildiğinde çalışacak olan method
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Eğer temas eden nesnenin etiketi "Player" ise
        {
            CharacterHealth characterHealth = other.GetComponent<CharacterHealth>();
            if (characterHealth != null)
            {
                characterHealth.TakeDamage(damage); // Karakterin canını belirtilen hasar kadar azalt
            }

            Destroy(gameObject); // Oku yok et
        }
    }
}
