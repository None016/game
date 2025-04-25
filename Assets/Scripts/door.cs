using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class door : MonoBehaviour
{
    public int namberScene;
    public Animator anim;
    public GameObject hiro;

    public bool dontSetVector2d = false;


    private bool isTriger = false;


    public SpriteRenderer outlineSprite; // Ссылка на SpriteRenderer обводки

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, вошел ли игрок
        {
            outlineSprite.enabled = true; // Включаем обводку
            isTriger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            outlineSprite.enabled = false; // Выключаем обводку
            isTriger = false;
        }
    }

    async void Update()
    {
        if (isTriger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hiro != null && !dontSetVector2d)
                {
                    Vector2_level4.x = hiro.transform.position.x;
                    Vector2_level4.y = hiro.transform.position.y;
                }

                anim.SetBool("drking", true);
                await Task.Delay(1000);

                SceneManager.LoadScene(namberScene);
            }
        }

    }
}
