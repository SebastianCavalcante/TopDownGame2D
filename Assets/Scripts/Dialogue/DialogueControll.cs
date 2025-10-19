using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class DialogueControll : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj; // janela dialogo
    public Image profileSprite; // Sprite do perfil
    public Text speechText;     // texto da fala
    public Text actorNameText;  // Nome do NPC

    [Header("Settings")]
    public float typingSpeed; // Velocidade da fala do npc


    // Variaveis de controle
    private bool isShowing; // Se a janena estiver visivel sera true
    private int index;       // index das sentenças
    private string[] sentence;


    public static DialogueControll instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Percorre a string de fala no array e o exibe na ui letra por letra
    IEnumerator TypeSentence()
    {
        foreach(char letter in sentence[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Pula para proxima fala 
    public void NextSentence()
    {
        if (speechText.text == sentence[index])
        {
            if (index < sentence.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentence = null;
                isShowing = false;
            }
        }
    }

    // chama a fala do npc
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentence = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
