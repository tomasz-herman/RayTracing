using System;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using OpenTK.Platform;
using RayTracing;
using RayTracing.Cameras;
using RayTracing.Lights;
using RayTracing.Maths;
using RayTracing.Models;
using RayTracing.Shaders;
using RayTracing.World;
using ButtonState = OpenTK.Input.ButtonState;
using Camera = RayTracing.Cameras.Camera;
using Timer = System.Windows.Forms.Timer;

namespace RayTracerApp.Forms
{
    public partial class MainForm : Form
    {
        private Scene scene = new Scene();
        private IRenderer _renderer;
        private Camera _camera = new PerspectiveCamera(new Vector3(0, 0, 20)) {AspectRatio = 1};
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
            _cameraController = new CameraController(_camera, gLControl);
            scene.AmbientLight = new AmbientLight {Color = Color.FromColor4(Color4.LightSkyBlue)};
            scene.AddModel(new Sphere {Position = new Vector3(0, 0, 0), Scale = 2}.Load());
            scene.AddModel(new Sphere {Position = new Vector3(0, 2, 0), Scale = 1}.Load());
            scene.AddModel(new Sphere {Position = new Vector3(0, 15, 0), Scale = 5}.Load());
            scene.AddModel(new Cube {Position = new Vector3(5, 0, 4), Scale = 3}.Load());

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
            _camera.AspectRatio = gLControl.Width / (float) gLControl.Height;
            gLControl.Invalidate();
        }


        private void newObjectButton_Click(object sender, EventArgs e)
        {
            var form = new NewObjectForm();
            form.SetController(new NewObjectController(scene));
            form.Show();
        }
    }
}