using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using OpenTK.Platform;
using RayTracer;
using RayTracer.Cameras;
using RayTracer.Models;
using RayTracer.Utils;
using RayTracer.World;
using ButtonState = OpenTK.Input.ButtonState;
using Camera = RayTracer.Cameras.Camera;
using Timer = System.Windows.Forms.Timer;

namespace RayTracerApp
{
    public partial class MainForm : Form
    {
        private Scene scene = new Scene();
        private IRenderer _renderer;
        private Camera _camera = new PerspectiveCamera{Position = new Vector3(0, 0, 20), AspectRatio = 1};
        private CameraController _cameraController;
        Timer FpsTimer = new Timer();

        public MainForm()
        {
            InitializeComponent();
        }

        private void GLControl_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.DepthTest);
            _renderer = new Renderer();
            _cameraController = new CameraController(_camera);
            scene.AddModel(new Sphere(new Vector3(0,0,0), 10));
            
            InitializeFpsTimer();
            UpdateViewport();
        }

        private void InitializeFpsTimer()
        {
            FpsTimer.Interval = 8;
            FpsTimer.Enabled = true;
            FpsTimer.Tick += OnTimerTick;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _cameraController.UpdateCamera(FpsTimer.Interval);

            _renderer.Render(scene, _camera);
            gLControl.SwapBuffers();
        }

        private void OnResize(object sender, EventArgs e)
        {
            UpdateViewport();
        }

        private void UpdateViewport()
        {
            gLControl.Height = Height;
            gLControl.Width = Width;
            GL.Viewport(0, 0, Width, Height);
            _camera.AspectRatio = gLControl.Width / (float)gLControl.Height;
            gLControl.Invalidate();
        }
    }
}