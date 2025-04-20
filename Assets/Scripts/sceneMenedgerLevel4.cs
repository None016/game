using System.Threading.Tasks;
using UnityEngine;

public class sceneMenedgerLevel4 : MonoBehaviour
{
    public GameObject hero;
    public GameObject camer;
    public Animator anim;


    async void Start()
    {
        Debug.Log(Vector2_level4.x);
        hero.transform.position = new Vector2(Vector2_level4.x, Vector2_level4.y);
        camer.transform.position = new Vector3(Vector2_level4.x, Vector2_level4.y + 1f, camer.transform.position.z);

        if (Vector2_level4.first)
        {
            Vector2_level4.first = false;
            await Task.Delay(2000);
            anim.SetBool("show", true);
            await Task.Delay(2000);
            anim.SetBool("show", false);
        }
        
    }
}
