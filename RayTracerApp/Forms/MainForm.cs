using System;
using System.ComponentModel;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using RayTracing;
using RayTracing.Cameras;
using RayTracing.Lights;
using RayTracing.Materials;
using RayTracing.Maths;
using RayTracing.Models;
using RayTracing.Sampling;
using RayTracing.World;
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
        private IncrementalRayTracer _rayTracer;
        private BackgroundWorker _backgroundWorker;
        Timer FpsTimer = new Timer();

        public MainForm()
        {
            InitializeComponent();
            _backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _backgroundWorker.DoWork += StartRender;
            _backgroundWorker.ProgressChanged += BackgroundWorkerProgressChanged;
        }

        private void GLControl_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.DepthTest);
            _renderer = new Renderer();
            _rayTracer = new IncrementalRayTracer(10, 64, Vec2Sampling.Jittered, gLControl.Width);
            _cameraController = new CameraController(_camera, gLControl);
            scene.AmbientLight = new AmbientLight {Color = Color.FromColor4(Color4.LightSkyBlue)};
            scene.AddModel(new Sphere
            {
                Position = new Vector3(0, 0.5f, 0), Scale = 1, Material = new Diffuse(Color.FromColor4(Color4.Orange))
            });
            scene.AddModel(new Sphere
            {
                Position = new Vector3(-2.5f, 0.5f, 1), Scale = 1,
                Material = new Reflective(Color.FromColor4(Color4.Azure), 0.1f)
            });
            scene.AddModel(new Sphere
            {
                Position = new Vector3(2.5f, 0.5f, 1), Scale = 1,
                Material = new Reflective(Color.FromColor4(Color4.Aqua), 0.75f)
            });
            scene.AddModel(new Plane
            {
                Position = new Vector3(0, -0.5f, 0), Scale = 1,
                Material = new Diffuse(Color.FromColor4(Color4.ForestGreen))
            });

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

            // _renderer.Render(scene, _camera);
            //gLControl.SwapBuffers();
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
            _rayTracer.Resolution = gLControl.Width;
        }

        private void StartRender(object sender, DoWorkEventArgs e)
        {
            _rayTracer.Render(scene, _camera, (a, t) =>
            {
                _backgroundWorker.ReportProgress(a,t);
            });
        }
        
        private void BackgroundWorkerProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            (e.UserState as Texture)?.Blit();
            gLControl.SwapBuffers();
            Text = e.ProgressPercentage + "%";
        }

        private void newObjectButton_Click(object sender, EventArgs e)
        {
            _backgroundWorker.RunWorkerAsync();
            // var form = new NewObjectForm();
            // form.SetController(new NewObjectController(scene));
            // form.Show();
        }
    }
}