using UnityEngine;

public class StartMonolog : MonoBehaviour
{

    public Animator animDialog;
    public Animator anim—lue;

    private bool inTriger = false;
    private bool dialogIsPlay = false;

    void Update()
    {
        if (inTriger)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                animDialog.SetBool("dialog", true);

                dialogIsPlay = true;
                anim—lue.SetInteger("stay", 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTriger = true;

            if (!dialogIsPlay)
            {
                anim—lue.SetInteger("stay", 1);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTriger = false;

            if (!dialogIsPlay)
            {
                anim—lue.SetInteger("stay", 0);
            }
        }
    }
}
