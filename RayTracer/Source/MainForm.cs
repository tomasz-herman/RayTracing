using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.ES30;
using OpenTK.Input;
using RayTracer.Cameras;
using RayTracer.Models;
using RayTracer.Renderer;
using RayTracer.Utils;

namespace RayTracer
{
    public partial class MainForm : Form
    {
        private bool _loaded;
        private Shader shader;
        private Model model;
        private IRenderer _renderer;
        private LoadedModel lm;
        private ICamera _camera;
        private bool _firstMove;
        private Vector2 _lastPos;
        Timer t = new Timer();

        public MainForm()
        {
            InitializeComponent();
        }

        private void GLControl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0.3f, 0.2f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.Viewport(0, 0, gLControl.Width, gLControl.Height);
            shader = new Shader("shader.vert", "shader.frag");
            shader.Use();
            _loaded = true;
            gLControl.Invalidate();
            var positions = new List<float>() {0f, 0f, 0f, 1f, 1f, 0f, 1f, 0f, 0f};
            var indices = new List<int>() {0, 1, 2};
            lm = new LoadedModel {mesh = new Mesh(positions, indices)};
            _renderer = new Renderer.Renderer();
            _camera = new MovingCamera(new Vector3(-1, 0, -1), 1);
        }

        private void GLControl_Resize(object sender, EventArgs e)
        {
            if (!_loaded)
                return;
            GL.Viewport(0, 0, gLControl.Width, gLControl.Height);
            gLControl.Invalidate();
        }

        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            shader.SetMatrix4("view", _camera.GetViewMatrix());
            shader.SetMatrix4("projection", _camera.GetProjectionMatrix());
            Log.Info("View: \n" + _camera.GetViewMatrix());
            Log.Info("View: \n" + _camera.GetProjectionMatrix());
            _renderer.Render(shader, lm);
            gLControl.SwapBuffers();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            t.Interval = 16;
            t.Enabled = true;

            t.Tick += TimerTick;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            var keyboard = Keyboard.GetState();
            const float cameraSpeed = 0.015f;
            const float sensitivity = 0.2f;

            if (keyboard.IsKeyDown(Key.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * t.Interval / 1000; // Forward
            }

            if (keyboard.IsKeyDown(Key.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * t.Interval / 1000; // Backwards
            }

            if (keyboard.IsKeyDown(Key.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * t.Interval / 1000; // Left
            }

            if (keyboard.IsKeyDown(Key.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * t.Interval / 1000; // Right
            }

            if (keyboard.IsKeyDown(Key.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * t.Interval / 1000; // Up
            }

            if (keyboard.IsKeyDown(Key.LShift))
            {
                _camera.Position -= _camera.Up * cameraSpeed * t.Interval / 1000; // Down
            }

            //
            // Get the mouse state
            var mouse = Mouse.GetState();

            if (_firstMove) // this bool variable is initially set to true
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                // Calculate the offset of the mouse position
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);

                // Apply the camera pitch and yaw (we clamp the pitch in the camera class)
                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity; // reversed since y-coordinates range from bottom to top
            }

            gLControl.Invalidate();
        }
    }
}