using Unity.VisualScripting;
using UnityEngine;

public class takeBook : MonoBehaviour
{
    public GameObject imageObject;
    public Animator anim;

    public GameObject book;


    private bool isTriger = false;
    public bool isTakeBook = false;

    void Update()
    {
        if (isTriger)
        {
            if (!isTakeBook)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    book.SetActive(false);
                    isTakeBook = true;
                    anim.SetInteger("stay", 0);
                }
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
        if (!isTakeBook)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                imageObject.SetActive(true);
                anim.SetInteger("stay", 1);
                isTriger = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isTakeBook)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //imageObject.SetActive(false);
                anim.SetInteger("stay", 0);
                isTriger = false;
            }
        }
    }
}
