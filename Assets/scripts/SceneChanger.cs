using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string targetSceneName = "sanat"; // Hedef sahnenin adı

    private bool canChangeScene = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canChangeScene = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canChangeScene = false;
        }
    }
private void Update()
{
    if ((canChangeScene && Input.GetKeyDown(KeyCode.F)) || (canChangeScene && Input.GetButtonDown("Fire3")))
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
}