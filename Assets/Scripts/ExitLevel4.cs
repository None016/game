using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel4 : MonoBehaviour
{

    public string scene;
    public Animator anim;
    public Animator tolk;

    async private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Vector2_level4.take_lectures)
            {
                anim.SetBool("drking", true);
                await Task.Delay(1000);

                SceneManager.LoadScene(scene);
            }
            else
            {
                tolk.SetBool("play", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tolk.SetBool("play", false);
        }
    }

}
