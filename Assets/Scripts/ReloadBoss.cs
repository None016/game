using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadBoss : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene(13);
        }
    }
}
