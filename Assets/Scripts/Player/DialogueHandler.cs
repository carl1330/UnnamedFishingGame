using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Image dialogueBox;

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.gameObject.SetActive(false);
    }

    public void startDialogue(Dialogue d)
    {
        sentences.Clear();

        nameText.text = d.stats.playerName;

        foreach(string sentence in d.sentences) {
            sentences.Enqueue(sentence);
        }

        displayNextSentence();

        dialogueBox.gameObject.SetActive(true);
    }

    public bool displayNextSentence()
    {
        if(sentences.Count == 0)
        {
            endDialogue();
            return false;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(typeSentence(sentence));
        return true;
    }

    IEnumerator typeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char c in sentence.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void endDialogue()
    {
        dialogueBox.gameObject.SetActive(false);
    }



}
