using UnityEngine;

namespace Code
{

}
public sealed class AudioSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _background;
    [SerializeField] private AudioClip[] _backgroundSounds;

    private void Start()
    {
        _background.clip = _backgroundSounds[Random.Range(0, _backgroundSounds.Length)];
        _background.Play();
    }
}
