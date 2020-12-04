using System.Drawing;
using System.Windows.Forms;
using RayTracing.Cameras;
using RayTracerApp.Utils;

namespace RayTracerApp
{
    public class CameraController
    {
        private bool _firstMouseMove;
        private Point _lastMousePos;
        private Camera _camera;
        public float Sensitivity = 0.002f;
        public float CameraSpeed = 0.02f;

        private DictionaryWithDefault<Keys, bool> keys = new DictionaryWithDefault<Keys, bool>();


        public CameraController(Camera camera, Control control)
        {
            _camera = camera;
            control.MouseMove += UpdateCameraOrientation;
            control.KeyDown += OnKeyDown;
            control.KeyUp += OnKeyUp;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            keys[e.KeyCode] = false;
            if (!e.Shift) keys[Keys.LShiftKey] = false;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            keys[e.KeyCode] = true;
            if (e.Shift) keys[Keys.LShiftKey] = true;
        }

        public void UpdateCamera(float msElapsed)
        {
            UpdateCameraPosition(msElapsed);
        }

        private void UpdateCameraOrientation(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_firstMouseMove)
                {
                    _lastMousePos = e.Location;
                    _firstMouseMove = false;
                }
                else
                {
                    var deltaX = e.Location.X - _lastMousePos.X;
                    var deltaY = e.Location.Y - _lastMousePos.Y;
                    _lastMousePos = e.Location;

                    _camera.Rotate(-deltaY * Sensitivity, deltaX * Sensitivity, 0);
                }
            }
            else
            {
                _firstMouseMove = true;
            }
        }

        private void UpdateCameraPosition(float msElapsed)
        {
            float dx = 0, dy = 0, dz = 0;
            if (keys[Keys.W])
            {
                dz += CameraSpeed * msElapsed;
            }

            if (keys[Keys.S])
            {
                dz -= CameraSpeed * msElapsed; // Backwards
            }

            if (keys[Keys.A])
            {
                dx -= CameraSpeed * msElapsed; // Left
            }

            if (keys[Keys.D])
            {
                dx += CameraSpeed * msElapsed; // Right
            }

            if (keys[Keys.Space])
            {
                dy += CameraSpeed * msElapsed; // Up
            }

            if (keys[Keys.LShiftKey])
            {
                dy -= CameraSpeed * msElapsed; // Down
            }

            _camera.Move(dx, dy, dz);
        }
    }
}