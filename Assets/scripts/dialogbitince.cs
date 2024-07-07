using System.Collections;
using System.Collections.Generic; // List sınıfını ekledik
using UnityEngine;
using TMPro;

public class dialogbitince : MonoBehaviour
{
    public TMP_Text dialogueText;
    public GameObject imageToShowAfterDialog; // Resmi içeren GameObject

    public float writingSpeed = 0.05f;
    private int index;
    private int charIndex;
    private bool started;
    private bool waitForNext;

    // Diyaloglar listesi
    public List<string> dialogues;

    private void Start()
    {
        ToggleImage(false);
    }

    private void ToggleImage(bool show)
    {
        if (imageToShowAfterDialog != null)
        {
            imageToShowAfterDialog.SetActive(show);
        }
    }

    public void StartDialogue()
    {
        if (started)
            return;

        started = true;
        ToggleImage(false);
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        index = i;
        charIndex = 0;
        dialogueText.text = string.Empty;
        StartCoroutine(Writing());
    }

    public void EndDialogue()
    {
        started = false;
        waitForNext = false;
        StopAllCoroutines();

        // Show the image after the dialogue ends
        ToggleImage(true);
    }

    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = GetNextDialogue();
        dialogueText.text += currentDialogue[charIndex];
        charIndex++;

        if (charIndex < currentDialogue.Length)
        {
            yield return new WaitForSeconds(writingSpeed);
            StartCoroutine(Writing());
        }
        else
        {
            waitForNext = true;
        }
    }

    private string GetNextDialogue()
    {
        if (index < dialogues.Count)
        {
            return dialogues[index];
        }
        else
        {
            return string.Empty;
        }
    }

    private void Update()
    {
        if (!started)
            return;

        if (waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;

            string nextDialogue = GetNextDialogue();
            if (!string.IsNullOrEmpty(nextDialogue))
            {
                GetDialogue(index);
            }
            else
            {
                EndDialogue();
            }
        }
    }
}