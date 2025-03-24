using UnityEngine;
using UnityEngine.SceneManagement;
using static exit;

public class exit : MonoBehaviour
{

    public int namberScene;
    public GameObject book;

    private bool isTakeBook = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTakeBook = book.GetComponent<takeBook>().isTakeBook;
        if (isTakeBook)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(namberScene);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isTakeBook)
        {
            if (collision.gameObject.CompareTag("Player"))
            {

            }
        }
    }

}
