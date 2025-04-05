using System.Threading.Tasks;
using UnityEngine;

public class SceneMenadger : MonoBehaviour
{
    public Animator anim;
    async void Start()
    {
        anim.SetBool("manifestation", true);
        await Task.Delay(500);
        anim.SetBool("manifestation", false);
    }
}
