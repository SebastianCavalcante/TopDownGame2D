using UnityEngine;
using System.Collections.Generic;

public class Npc : MonoBehaviour
{
    private float speed;
    public float initialSpeed;
    private int index;
    private Animator anim;

    public List<Transform> path = new List<Transform>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogueControll.instance.IsShowing)
        {
            speed = initialSpeed;
            anim.SetBool("isWalking", true);
        }
        else
        {
            speed = 0;
            anim.SetBool("isWalking", false);
        }

            // movimenta um objeto a partir de um ponto de origem ate um de destino em uma velocidade especificada
            transform.position = Vector2.MoveTowards(transform.position, path[index].position, speed * Time.deltaTime);

        // verifica se o npc esta proximo do path de destino
        if (Vector2.Distance(transform.position, path[index].position) < 0.1f)
        {
            if (index < path.Count - 1)
            {
                index++;

            }
            else
            {
                index = 0;
            }
        }

        Vector2 direction = path[index].position - transform.position; // armazena a posição entre o npc e seu path de destino

        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0); // rotaciona o npc para direita
        }
        else if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180); // rotaciona o npc para esquerda
        }
    }
}