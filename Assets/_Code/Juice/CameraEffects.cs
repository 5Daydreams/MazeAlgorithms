using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Code.Juice
{
    public class CameraEffects : MonoBehaviour
    {
        private Vector3 _startPos;
        private float _startOrtoSize;
        private Camera _camera;

        private void Awake()
        {
            _camera = FindObjectOfType<Camera>();
            _startPos = transform.localPosition;
            _startOrtoSize = _camera.orthographicSize;
        }

        public IEnumerator Shake(float duration, float intensity)
        {
            float elapsedTime = 0.0f;

            while (elapsedTime < duration)
            {
                float x = Random.Range(-1.0f, 1.0f) * intensity;
                float y = Random.Range(-1.0f, 1.0f) * intensity;
                float z = Random.Range(-1.0f, 1.0f) * intensity;

                transform.localPosition = new Vector3(_startPos.x + x, _startPos.y + y, _startPos.z);

                elapsedTime += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = _startPos;
        }

        public IEnumerator ScreenKick(float duration, float downscaling)
        {
            float elapsedTime = 0.0f;
            _camera.orthographicSize *= downscaling;

            var remainingScaling = downscaling-1;
        
            while (elapsedTime < duration)
            {
                _camera.orthographicSize -= remainingScaling / duration;

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _camera.orthographicSize = _startOrtoSize;
        }
    }
}