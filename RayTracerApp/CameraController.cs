using System;
using System.Drawing;
using System.Windows.Forms;
using RayTracing.Cameras;
using RayTracerApp.Utils;
using System.Collections.Generic;

namespace RayTracerApp
{
    public class CameraController : IDisposable
    {
        public float Sensitivity = 0.002f;
        public float CameraSpeed = 0.02f;

        public bool Blocked { get; set; } = false;

        private Action _onModification;
        private bool _firstMouseMove;
        private Point _lastMousePos;
        private Camera _camera;
        private DictionaryWithDefault<Keys, bool> keys = new DictionaryWithDefault<Keys, bool>();
        private List<Keys> allowedKeys = new List<Keys> { Keys.W, Keys.A, Keys.S, Keys.D, Keys.LShiftKey, Keys.Space };
        private Control _control;
        public CameraController(Camera camera, Control control, Action onModification)
        {
            _camera = camera;
            _control = control;
            _control.MouseMove += UpdateCameraOrientation;
            _control.KeyDown += OnKeyDown;
            _control.KeyUp += OnKeyUp;
            _onModification = onModification;
        }


        public Camera GetCamera()
        {
            return _camera;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (Blocked) return;
            if (!allowedKeys.Contains(e.KeyCode)) return;
           
            keys[e.KeyCode] = false;
            if (!e.Shift) keys[Keys.LShiftKey] = false;
            _onModification();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (Blocked) return;
            if (!allowedKeys.Contains(e.KeyCode)) return;
            keys[e.KeyCode] = true;
            if (e.Shift) keys[Keys.LShiftKey] = true;
            _onModification();
        }

        public void UpdateCamera(float msElapsed)
        {
            if (Blocked) return;
            UpdateCameraPosition(msElapsed);
        }

        private void UpdateCameraOrientation(object sender, MouseEventArgs e)
        {
            if (Blocked) return;
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
                    _onModification();
                }
            }
            else
            {
                _firstMouseMove = true;
            }
        }

        private void UpdateCameraPosition(float msElapsed)
        {
            if (Blocked) return;
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

        public void Dispose()
        {
            _control.MouseMove -= UpdateCameraOrientation;
            _control.KeyDown -= OnKeyDown;
            _control.KeyUp -= OnKeyUp;
        }
    }
}