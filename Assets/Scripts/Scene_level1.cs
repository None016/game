using System.Threading.Tasks;
using UnityEngine;

public class startlocation : MonoBehaviour
{
    public Animator anim;
    async void Start()
    {
        await Task.Delay(2000);
        anim.SetBool("show", true);
        await Task.Delay(2000);
        anim.SetBool("show", false);
    }

}
