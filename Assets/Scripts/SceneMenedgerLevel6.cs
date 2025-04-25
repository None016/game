using System.Threading.Tasks;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Animator anim;
    async private void Start()
    {
        anim.SetBool("show", true);
        await Task.Delay(4000);
        anim.SetBool("show", false);
    }
}
