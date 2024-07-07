using UnityEngine;
using UnityEngine.SceneManagement;

public class Gece : MonoBehaviour
{
    public string targetSceneName = "oda3"; // Hedef sahnenin adı

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Eğer çarpışan nesne "Player" etiketine sahipse
        {
            SceneManager.LoadScene(targetSceneName); // Hedef sahneye geç
        }
    }
}