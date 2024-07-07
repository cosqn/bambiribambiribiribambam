using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickAndSceneTransition : MonoBehaviour
{
    private AudioSource _clickSound;

    private void Awake()
    {
        _clickSound = GetComponent<AudioSource>();

        if (_clickSound == null)
        {
            _clickSound = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnMouseDown()
    {
        StartCoroutine(ClickAction());
    }

    IEnumerator ClickAction()
    {
        // Tıklama sesini çal
        if (_clickSound.clip != null)
        {
            _clickSound.PlayOneShot(_clickSound.clip);
        }

        // Bir süre bekleyin (örneğin, 1 saniye)
        yield return new WaitForSeconds(10f);

        // Nesneyi biraz aşağı ve sağa kaydırma
        transform.position += new Vector3(0.2f, -0.2f, 0f);

        // Bir süre daha bekleyin
        yield return new WaitForSeconds(10f);

        // Diğer sahneye geç
        SceneManager.LoadScene("İkinciSahne"); // İkinciSahne, geçmek istediğiniz sahnenin adıyla değiştirilmelidir.
    }
}