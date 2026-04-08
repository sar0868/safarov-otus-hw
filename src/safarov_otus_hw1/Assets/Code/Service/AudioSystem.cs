using UnityEngine;
using UnityEngine.Audio;

namespace Code.Service
{

}
public sealed class AudioSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _background;
    [SerializeField] private AudioClip[] _backgroundSounds;
    [SerializeField] private AudioMixer _audioMixer;

    private void Start()
    {
        _background.clip = _backgroundSounds[Random.Range(0, _backgroundSounds.Length)];
        _background.Play();
        _audioMixer.SetFloat("volume_bg", -20f);
        _audioMixer.SetFloat("volume_step", 10f);
    }
}
