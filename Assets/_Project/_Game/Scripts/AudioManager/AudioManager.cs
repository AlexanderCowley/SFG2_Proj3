using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager _instance;

    AudioSource _audioSource;

    public AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
                if (_instance == null)
                {
                    GameObject newGameObject = new GameObject("Audio Manager (Singleton Instance");

                    AudioManager audioManager = newGameObject.AddComponent<AudioManager>();
                    _instance = audioManager;
                    DontDestroyOnLoad(newGameObject);
                }
            }           
            return _instance;
        }
    }

    private void Awake()
    {
        AudioSourceInit();
    }

    void AudioSourceInit()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        //Settings
    }

    public void PlayClip(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }

    public void StopClip()
    {

    }

    public void ReplaceClip()
    {

    }

    public void PauseClip()
    {
        
    }

    public void RewindClip()
    {

    }

    public void DecrementVolume()
    {
        //lower volume until mute and then stop
    }
}