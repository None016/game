using UnityEngine;

public class sceneMenedgerLevel4 : MonoBehaviour
{
    public GameObject hero;
    public GameObject camera;
    public VectorPlayer vectorPlayer;

    void Start()
    {
        hero.transform.position = new Vector2(vectorPlayer.playerVector.x, vectorPlayer.playerVector.y);
        camera.transform.position = new Vector3(vectorPlayer.playerVector.x, vectorPlayer.playerVector.y + 1f, camera.transform.position.z);
    }
}
