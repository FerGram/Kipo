using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField] AudioClip _backgroundMusic;
    private AudioSource _audioSource;

    private void Awake()
    {
        if(instance == null) { instance = this; DontDestroyOnLoad(this); }
        else { Destroy(gameObject); }
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _backgroundMusic;
        _audioSource.Play();
    }

    public void PlaySong() { _audioSource.Play(); }
    public void StopSong() { _audioSource.Stop(); }
}
