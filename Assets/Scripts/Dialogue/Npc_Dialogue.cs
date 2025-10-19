using System.Collections.Generic;
using UnityEngine;

public class Npc_Dialogue : MonoBehaviour
{
    public float dialogueRange;   // define o tamanho do colisor de decção
    public LayerMask playerLayer; // layer para detectar o player

    bool playerHit;

    public DialogueSettings dialogue;
    private List<string> setences =  new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetNpcInfo();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControll.instance.Speech(setences.ToArray());
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        ShowDialogue();
    }


    // Retorna caso o player seja detectado 
    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
        }
    }


    void GetNpcInfo()  
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControll.instance.language)
            {
                case DialogueControll.idiom.pt:
                    setences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;
                case DialogueControll.idiom.eng:
                    setences.Add(dialogue.dialogues[i].sentence.english);
                    break;
                case DialogueControll.idiom.spa:
                    setences.Add(dialogue.dialogues[i].sentence.spanish);
                    break;
            }
            
        }
    }

    // Desenha um gismo com referencias da posição atual e tamanho em range.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
