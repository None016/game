using UnityEngine;

public class Win : MonoBehaviour
{
    public Animator anim;
    public void WinGame()
    {
        anim.SetBool("win", true);
    }
}
