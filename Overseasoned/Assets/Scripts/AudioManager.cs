using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void SecondSpeedUp()
    {
        audioSource.pitch = 1.15f;
    }


}
