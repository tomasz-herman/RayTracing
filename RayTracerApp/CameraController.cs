using OpenTK;
using OpenTK.Input;
using RayTracer.Cameras;

namespace RayTracerApp
{
    public class CameraController
    {
        private bool _firstMouseMove;
        private Vector2 _lastMousePos;
        private Camera _camera;
        public float Sensitivity = 0.2f;
        public float CameraSpeed = 1f;

        public CameraController(Camera camera)
        {
            _camera = camera;
        }

        public void UpdateCamera(float msElapsed)
        {
            UpdateCameraOrientation(msElapsed);
            UpdateCameraPosition(msElapsed);
        }
        
        private void UpdateCameraOrientation(float msElapsed)
        {
            var mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                if (_firstMouseMove)
                {
                    _lastMousePos = new Vector2(mouse.X, mouse.Y);
                    _firstMouseMove = false;
                }
                else
                {
                    var deltaX = mouse.X - _lastMousePos.X;
                    var deltaY = mouse.Y - _lastMousePos.Y;
                    _lastMousePos = new Vector2(mouse.X, mouse.Y);
                    
                    _camera.Yaw += deltaX * Sensitivity;
                    _camera.Pitch -= deltaY * Sensitivity;
                }
            }
            else
            {
                _firstMouseMove = true;
            }
        }
        
        private void UpdateCameraPosition(float msElapsed)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Key.W))
            {
                _camera.Position += _camera.Front * msElapsed * CameraSpeed / 1000; // Forward
            }

            if (keyboard.IsKeyDown(Key.S))
            {
                _camera.Position -= _camera.Front * msElapsed * CameraSpeed / 1000; // Backwards
            }

            if (keyboard.IsKeyDown(Key.A))
            {
                _camera.Position -= _camera.Right * msElapsed * CameraSpeed / 1000; // Left
            }

            if (keyboard.IsKeyDown(Key.D))
            {
                _camera.Position += _camera.Right * msElapsed * CameraSpeed / 1000; // Right
            }

            if (keyboard.IsKeyDown(Key.Space))
            {
                _camera.Position += _camera.Up * msElapsed * CameraSpeed / 1000; // Up
            }

            if (keyboard.IsKeyDown(Key.LShift))
            {
                _camera.Position -= _camera.Up * msElapsed * CameraSpeed / 1000; // Down
            }
        }
    }
}