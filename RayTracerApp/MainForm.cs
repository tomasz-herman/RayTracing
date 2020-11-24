using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using RayTracer;
using RayTracer.Cameras;
using RayTracer.Models;
using RayTracer.Utils;
using ButtonState = OpenTK.Input.ButtonState;

namespace RayTracerApp
{
    public partial class MainForm : Form
    {
        private bool _loaded;
        private Shader shader;
        private Model model;
        private IRenderer _renderer;
        private Model lm;
        private Camera _camera;
        private bool _firstMove;
        private Vector2 _lastPos;
        Timer FpsTimer = new Timer();

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
            lm = new Sphere(new Vector3(0,0,0), 10);//ModelLoader.Load("../../../../Resources/Models/sphere.obj", PostProcessSteps.Triangulate);
            _renderer = new Renderer();
            _camera = new PerspectiveCamera(new Vector3(0, 0, -5), 1);
            _renderer.Render(shader, lm);
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
            InitializeFpsTimer();
        }

        private void InitializeFpsTimer()
        {
            FpsTimer.Interval = 16;
            FpsTimer.Enabled = true;
            FpsTimer.Tick += OnNewFrame;
        }

        private void OnNewFrame(object sender, EventArgs e)
        {
            var keyboard = Keyboard.GetState();
            const float cameraSpeed = 0.15f;
            const float sensitivity = 0.2f;

            if (keyboard.IsKeyDown(Key.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * FpsTimer.Interval / 1000; // Forward
            }

            if (keyboard.IsKeyDown(Key.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * FpsTimer.Interval / 1000; // Backwards
            }

            if (keyboard.IsKeyDown(Key.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * FpsTimer.Interval / 1000; // Left
            }

            if (keyboard.IsKeyDown(Key.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * FpsTimer.Interval / 1000; // Right
            }

            if (keyboard.IsKeyDown(Key.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * FpsTimer.Interval / 1000; // Up
            }

            if (keyboard.IsKeyDown(Key.LShift))
            {
                _camera.Position -= _camera.Up * cameraSpeed * FpsTimer.Interval / 1000; // Down
            }
            
            var mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                if (_firstMove)
                {
                    _lastPos = new Vector2(mouse.X, mouse.Y);
                    _firstMove = false;
                }
                else
                {
                    var deltaX = mouse.X - _lastPos.X;
                    var deltaY = mouse.Y - _lastPos.Y;
                    _lastPos = new Vector2(mouse.X, mouse.Y);
                    
                    _camera.Yaw += deltaX * sensitivity;
                    _camera.Pitch -= deltaY * sensitivity;
                }
            }
            else
            {
                _firstMove = true;
            }
            
            gLControl.Invalidate();
        }

        private void OnResize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (!_loaded)
                return;
            gLControl.Height = control.Height;
            gLControl.Width = control.Width;
            GL.Viewport(0, 0, control.Width, control.Height);
            _camera.AspectRatio = gLControl.Width / (float)gLControl.Height;
            gLControl.Invalidate();
        }
    }
}