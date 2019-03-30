using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    private void Start()
    {
        StartCoroutine(StartCutScene());
    }

    IEnumerator StartCutScene()
    {
        yield return new WaitForSeconds(1f);
        TriggerDialogue();
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
