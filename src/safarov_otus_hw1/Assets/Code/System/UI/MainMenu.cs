using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.System.UI
{
    public sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _lightBtn;
        [SerializeField] private Button _probsBtn;
        [SerializeField] private Button _postProcessingBtn;
        [SerializeField] private Button _batchingBtn;
        [SerializeField] private Button _LODCullingBtn;


        private void OnEnable()
        {
            _lightBtn.onClick.AddListener(SceneLighting);
            _probsBtn.onClick.AddListener(SceneLighting);
            _postProcessingBtn.onClick.AddListener(ScenePostProcessing);
            _batchingBtn.onClick.AddListener(SceneBatching);
            _LODCullingBtn.onClick.AddListener(SceneLighting);

        }

        private void OnDisable()
        {
            _lightBtn.onClick.RemoveListener(SceneLighting);
            _probsBtn.onClick.RemoveListener(SceneProbs);
            _postProcessingBtn.onClick.RemoveListener(SceneLighting);
            _batchingBtn.onClick.RemoveListener(SceneBatching);
            _LODCullingBtn.onClick.RemoveListener(ScenLODCulling);
        }

        private void SceneLighting()
        {
            SceneManager.LoadScene("SceneLighting");
        }
        private void SceneProbs()
        {
            SceneManager.LoadScene("SceneProbs");
        }
        private void ScenePostProcessing()
        {
            SceneManager.LoadScene("ScenePostProcessing");
        }
        private void SceneBatching()
        {
            SceneManager.LoadScene("SceneBatching");
        }
        private void ScenLODCulling()
        {
            SceneManager.LoadScene("ScenLODCulling");
        }
    }
}

