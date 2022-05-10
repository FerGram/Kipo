using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip _deathSFX;
    [SerializeField] AudioClip _jumpSFX;
    [SerializeField] AudioClip _levelPassedSFX;

    [SerializeField] private List<AudioClip> _randomRobotAudio;
    [SerializeField] bool _robotSaysRandomThings;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        SetManagerForPhrases();
        if (_robotSaysRandomThings)
        {
            SetRandomRobotVoice();
        }
    }
    private void SetManagerForPhrases()
    {
        Phrases[] phrases = FindObjectsOfType<Phrases>();
        foreach (Phrases p in phrases)
        {
            p.SetNewAudioManager();
        }
    }
    private void SetRandomRobotVoice()
    {
        int random = Random.Range(0, _randomRobotAudio.Count + 4);
        try { PlayClip(_randomRobotAudio[random]); }
        catch { return; }
    }

    public void PlayClip(AudioClip clip)
    {
        if(clip != null) { _audioSource.PlayOneShot(clip); }
    }
    public void PlayerDeath()
    {
        _audioSource.PlayOneShot(_deathSFX);
    }
    public void PlayerJump()
    {
        _audioSource.PlayOneShot(_jumpSFX);
    }
    public void LevelPassed()
    {
        _audioSource.PlayOneShot(_levelPassedSFX);
    }
}
