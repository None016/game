using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneMenedgerlevel3 : MonoBehaviour
{
    public Animator anim;
    public VideoPlayer videoPlayer; // Ссылка на VideoPlayer
    public string nextSceneName;    // Имя сцены для загрузки

    async void Start()
    {
        anim.SetBool("manifestation", true);
        await Task.Delay(500);
        anim.SetBool("manifestation", false);

        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();

        // Подписываемся на событие окончания видео
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    async void OnVideoEnd(VideoPlayer vp)
    {
        anim.SetBool("drking", true);
        await Task.Delay(2000);

        SceneManager.LoadScene(nextSceneName);
    }

    void OnDestroy()
    {
        // Отписываемся от события при уничтожении объекта
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoEnd;
    }
}
