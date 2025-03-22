using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Event : MonoBehaviour
{
    public GameObject imageObject;
    public Animator anim;

    private void Start()
    {
        if (imageObject.activeSelf)
        {
            Debug.Log(3);
            imageObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(1);
            imageObject.SetActive(true);
            anim.SetInteger("stay", 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Debug.Log(2);
            //imageObject.SetActive(false);
            anim.SetInteger("stay", 0);
        }  
    }
}
