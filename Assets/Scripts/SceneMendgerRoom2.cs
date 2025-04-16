using System.Threading.Tasks;
using UnityEngine;

public class SceneMendgerRoom2 : MonoBehaviour
{
    public Animator anim;

    async void Start()
    {
        await Task.Delay(2000);
        anim.SetBool("start", true);
        await Task.Delay(100);
        anim.SetBool("start", false);
    }

}
