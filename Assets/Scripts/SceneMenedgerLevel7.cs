using System.Threading.Tasks;
using UnityEngine;

public class SceneMenedgerLevel7 : MonoBehaviour
{
    public Animator animHiro;

    async void Start()
    {
        await Task.Delay(1500);
        animHiro.SetBool("play", true);
        await Task.Delay(500);
        animHiro.SetBool("play", false);
    }
}
