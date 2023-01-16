using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    //Serialize sound NPC
    //[SerializeField] private AudioClip npcVoice;
    [SerializeField] private float typingTime;
   // [SerializeField] private int charsToPlaySound;


    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    public static bool dialogue = false;

    //Sound NPC Dialogue
   /* private AudioSource audioSource;*/

    private void Start()
    {
       /* audioSource = GetComponent<AudioSource>();
        audioSource.clip = npcVoice;*/
    }


    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player is in range");
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }
    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    // Corrutine typing text
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        int charIndex = 0;
        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            /* //Reproduce sound/ch
             if (charIndex % charsToPlaySound == 0)
             {
                 audioSource.Play();
             }*/
            charIndex++;
            yield return new WaitForSecondsRealtime(typingTime);
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogue = true;
            dialogueMark.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogue = false;
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }

    }
}

