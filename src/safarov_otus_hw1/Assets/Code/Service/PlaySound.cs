using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public sealed class PlaySound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioVillage;
        [SerializeField] private AudioClip _audioBattle;
        [SerializeField] private AudioClip _audioFuneral;
        [SerializeField] private AudioClip _audioPlace;
        [SerializeField] private AudioClip _audioCry;
        [SerializeField] private AudioClip _audioForest;

        public void VillageSound()
        {
            PlayAnmimationSound(_audioVillage);
        }

        public void BattleSound()
        {
            PlayAnmimationSound(_audioBattle);
        }
        public void FuneralSound()
        {
            PlayAnmimationSound(_audioFuneral);
        }
        public void PlaceSound()
        {
            PlayAnmimationSound(_audioPlace);
        }
        public void CrySound()
        {
            PlayAnmimationSound(_audioCry);
        }
        public void ForestSound()
        {
            PlayAnmimationSound(_audioForest);
        }

        public void End()
        {
            _audioSource.Stop();
            SceneManager.LoadScene("Level1");
        }


        private void PlayAnmimationSound(AudioClip audioClip)
        {
            _audioSource.Stop();
            if (audioClip != null && _audioSource != null)
            {
                _audioSource.PlayOneShot(audioClip);
            }
        }
    }
}
