using UnityEngine;

public class kill : MonoBehaviour
{

    public Animator anim;
    private bool isKill = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish") && !isKill)
        {
            isKill = true;
            Debug.Log("kill");
            anim.SetBool("loos", true);

        }
    }

}
