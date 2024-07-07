using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Eğer çarpan nesne "Player" etiketine sahipse ve bu nesne "levelgec" etiketine sahipse
            if (other.gameObject.CompareTag("levelgec"))
            {
                // Sahne 2'yi yükle
                SceneManager.LoadScene(2);
            }
        }
    }
}