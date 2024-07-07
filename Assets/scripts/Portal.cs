using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string destinationSceneName; // Değişim yapılacak sahnenin adı

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Eğer temas eden nesne "Player" etiketine sahipse
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(destinationSceneName); // Yeni sahneyi yükler
    }
}


