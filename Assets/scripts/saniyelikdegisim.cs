using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saniyelikdegisim : MonoBehaviour
{
    public string targetSceneName = "mutfak2"; // Hedef sahnenin adı
    public float timeToChangeScene = 20.0f; // Sahnenin değiştirilmesi gereken süre

    private float elapsedTime = 0.0f;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= timeToChangeScene)
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}