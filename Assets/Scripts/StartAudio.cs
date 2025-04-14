using UnityEngine;
using UnityEngine.Audio;

public class StartAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator anim—lue;

    private bool inTriger = false;
    private bool IsPlay = false;

    void Update()
    {
        if (inTriger)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {

                audioSource.Play();
                IsPlay = true;
                anim—lue.SetInteger("stay", 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTriger = true;

            if (!IsPlay)
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

            if (!IsPlay)
            {
                anim—lue.SetInteger("stay", 0);
            }
        }
    }
}
