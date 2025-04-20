using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;

public class TaceLection : MonoBehaviour
{
    private bool isTriger = false;
    public Animator anim;
    async void Update()
    {
        if (isTriger)
        {
            if (!Vector2_level4.take_lectures)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Vector2_level4.take_lectures = true;
                    Debug.Log(Vector2_level4.take_lectures);
                    anim.SetBool("show", true);
                    await Task.Delay(2000);
                    anim.SetBool("show", false);
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Vector2_level4.take_lectures)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isTriger = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!Vector2_level4.take_lectures)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isTriger = false;
            }
        }
    }
}
