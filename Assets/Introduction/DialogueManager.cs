using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;

    public Animator dialogueBoxAnimator;
    public Animator computerAnimator;
    public Animator lightAnimator;
    public Animator starLight;
    public Animator skipButtonAnimator;

    private MusicController music;

	// Use this for initialization
	void Start () {
        music = GetComponent<MusicController>();
        sentences = new Queue<string>();
        starLight.SetBool("Start", true);
	}
	
    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBoxAnimator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 9)
        {
            skipButtonAnimator.SetBool("IsOpen", true);
        }

        if (sentences.Count == 7)
        {
            computerAnimator.SetBool("IsOpen", true);
        }

        if (sentences.Count == 5)
        {
            computerAnimator.SetBool("IsOpen", false);
        }

        if (sentences.Count == 1)
            skipButtonAnimator.SetBool("IsOpen", false);

        if (sentences.Count == 0)
        {
            StartCoroutine(FinishCutScene());
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            music.BeatSound();
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        DisplayNextSentence();
    }

    public IEnumerator FinishCutScene()
    {
        lightAnimator.SetBool("Explosion", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("World");
    }

    public void SkipCutScene()
    {
        StopAllCoroutines();
        StartCoroutine(FinishCutScene());
    }
}
