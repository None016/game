using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Event : MonoBehaviour
{
    public GameObject imageObject;
    public Animator anim;


    private bool isTriger = false;

    void Update()
    {
        if (!isTriger) { 
            // Генерируем событие при нажатии клавиши Space
            if (Input.GetKeyDown(KeyCode.E))
            {

            }
        }
        
    }

    private void Start()
    {
        if (imageObject.activeSelf)
        {
            imageObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            imageObject.SetActive(true);
            anim.SetInteger("stay", 1);
            isTriger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            //imageObject.SetActive(false);
            anim.SetInteger("stay", 0);
            isTriger = false;
        }  
    }
}
