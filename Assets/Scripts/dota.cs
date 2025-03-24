using UnityEngine;

public class dota : MonoBehaviour
{
    public GameObject imageObject;
    public Animator anim;

    public GameObject thougts;



    private bool isTriger = false;

    void Update()
    {
        if (isTriger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                thougts.GetComponent<thoughts>().getnotNow1();
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
