using UnityEngine;

public class activateTriger : MonoBehaviour
{
    public GameObject triger;

    private bool inTriger;

    private void Start()
    {
        triger.SetActive(false);
    }

    void Update()
    {
        if (inTriger)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                triger.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTriger = true;

            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTriger = false;

            
        }
    }
}
