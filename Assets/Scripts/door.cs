using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public int namberScene;

    private bool isTriger = false;


    [SerializeField] private SpriteRenderer outlineSprite; // Ссылка на SpriteRenderer обводки

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

    void Update()
    {
        if (isTriger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(namberScene);
            }
        }

    }
}
