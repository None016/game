using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

public class AudioForRoom : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource audioSource;
    async void Start()
    {
        await Task.Delay(1000);
        audioSource.Play();
    }
}
