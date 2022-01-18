using UnityEngine;

namespace Assets.Scripts.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class CameraZooming : MonoBehaviour
    {
        private UnityEngine.Camera _Camera;

        public float Increment = .1f;
        public float MaxZoom = 4f;
        public float MinZoom = 9f;
        // Start is called before the first frame update
        void Start()
        {
            _Camera = GetComponent<UnityEngine.Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            float input = Input.GetAxis("Mouse ScrollWheel");
            if (input != 0f)
            {
                float value = Increment * input;
                float size = _Camera.orthographicSize;
                if (size - value <= MinZoom && size - value >= MaxZoom)
                    _Camera.orthographicSize -= value;
            }
        }
    }
}
