using UnityEngine;

public class SceneMenedgerRoom5 : MonoBehaviour
{
    public GameObject tr_botan;
    public GameObject tr_book;
    public GameObject img_book;
    void Start()
    {
        Debug.Log(Vector2_level4.take_lectures);
        if (Vector2_level4.take_lectures)
        {
            tr_botan.SetActive(false);
            tr_book.SetActive(false);
            img_book.SetActive(false);
        }
    }
}
