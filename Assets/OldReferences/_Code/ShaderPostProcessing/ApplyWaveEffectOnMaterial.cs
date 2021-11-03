using UnityEngine;

namespace _Code.ShaderPostProcessing
{
    public class ApplyWaveEffectOnMaterial : MonoBehaviour
    {
        [SerializeField] private Material _postprocessMaterial;
        [SerializeField] private float _waveSpeed;
        [SerializeField] private float _threshold;
        [SerializeField] private bool _waveActive;
        private float _waveDistance;

        private void OnEnable()
        {
            StartWave();
        }

        private void FixedUpdate()
        {
            if (!_waveActive)
                return;

            _waveDistance = _waveDistance + _waveSpeed * Time.deltaTime;
            _postprocessMaterial.SetFloat("_WaveValue", _waveDistance);

            if (_waveDistance >= _threshold)
                _waveActive = false;
        }

        [ContextMenu("StartWave")]
        public void StartWave()
        {
            _waveDistance = 0;
            _waveActive = true;
        }
    }
}