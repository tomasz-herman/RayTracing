using System;
using System.ComponentModel;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using RayTracerApp.Forms.Menu;
using RayTracing;
using RayTracing.Cameras;
using RayTracing.Lights;
using RayTracing.Materials;
using RayTracing.Models;
using RayTracing.Sampling;
using RayTracing.World;
using Camera = RayTracing.Cameras.Camera;
using Timer = System.Windows.Forms.Timer;
using RayTracerApp.SceneControllers;
using Color = RayTracing.Maths.Color;

namespace RayTracerApp.Forms
{
    public partial class MainForm : Form
    {
        private const int SWAP_TIME = 2;
        private Scene _scene = new Scene();
        private IRenderer _renderer;
        private Camera _camera = new PerspectiveCamera(new Vector3(0, 0, 20)) {AspectRatio = 1};
        private CameraController _cameraController;
        private IncrementalRayTracer _rayTracer;
        private BackgroundWorker _backgroundWorker;
        private Timer _fpsTimer = new Timer();
        private long lastModification;
        private bool rayTracingStarted;

        public void UpdateLastModification()
        {
            lastModification = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
            rayTracingStarted = false;
            _backgroundWorker?.CancelAsync();
        }

        public bool ShouldRaytrace()
        {
            long now = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
            return now - lastModification > SWAP_TIME;
        }

        public MainForm()
        {
            InitializeComponent();
            UpdateLastModification();
        }

        private void GLControl_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.DepthTest);
            _renderer = new Renderer();
            _rayTracer = new IncrementalRayTracer(10, 64 * 64, Vec2Sampling.Jittered, gLControl.Width, 50);
            _cameraController = new CameraController(_camera, gLControl, UpdateLastModification);
            _scene.AmbientLight = new AmbientLight {Color = Color.FromColor4(Color4.LightSkyBlue)};
            _scene.AddModel(new Sphere
            {
                Position = new Vector3(0, 5.5f, 0), Scale = 1,
                Material = new Emissive(Color.FromColor4(Color4.White))
            }.Load());
            _scene.AddModel(new Sphere
            {
                Position = new Vector3(-2.5f, 0.5f, 1), Scale = 1,
                Material = new Reflective(Color.FromColor4(Color4.Azure), 0.1f)
            }.Load());
            _scene.AddModel(new Sphere
            {
                Position = new Vector3(2.5f, 0.5f, 1), Scale = 1,
                Material = new Reflective(new Texture("earthmap.jpg"), 0.75f)
            }.Load());
            
            _scene.AddModel(new Triangle(
                new Vector3(-4f, 0f, -1f),
                new Vector3(-5f, 2f, 2.5f),
                new Vector3(-5f, -0.5f, 2f)
            ) {Material = new Reflective(Color.FromColor4(Color4.AliceBlue), 0.05f)});
            
            _scene.AddModel(new Cylinder(2)
            {
                Position = new Vector3(5f, 0.5f, 0), Scale = 1,
                Material = new Diffuse(Color.FromColor4(Color4.Chocolate))
            }.Load());
            _scene.AddModel(new Cylinder(2)
            {
                Position = new Vector3(5f, 0.5f, 4), Scale = 1,
                Material = new Diffuse(new Texture("earthmap.jpg"))
            }.Load());
            _scene.AddModel(new Cube()
            {
                Position = new Vector3(0, 0.5f, -3), Scale = 1,
                Material = new Reflective(new Texture("wood.jpg"), 0.75f),
                Rotation = Vector3.One * (float)Math.PI/6
            }.Load());
            // _scene.AddModel(new Rectangle(2)
            // {
            //     Position = new Vector3(0, 0.5f, -1.99f), Scale = 0.8f,
            //     Material = new Emissive(Color.FromColor4(Color4.White) * 8),
            //     Rotation = new Vector3((float) Math.PI / 2, 0, 0)
            // }.Load());
            _scene.AddModel(new Plane
            {
                Position = new Vector3(0, -0.5f, 0), Scale = 1,
                Material = new Diffuse(new Texture("wood.jpg"))
            }.Load());

            InitializeFpsTimer();
            UpdateViewport();
        }

        private void InitializeFpsTimer()
        {
            _fpsTimer.Interval = 8;
            _fpsTimer.Enabled = true;
            _fpsTimer.Tick += OnTimerTick;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _cameraController.UpdateCamera(_fpsTimer.Interval);

            if (!rayTracingStarted)
                if (ShouldRaytrace())
                {
                    InitializeBackgroundWorker();
                    _backgroundWorker.RunWorkerAsync();
                    rayTracingStarted = true;
                }
                else
                {
                    _renderer.Render(_scene, _camera);
                    gLControl.SwapBuffers();
                }
        }

        private void OnResize(object sender, EventArgs e)
        {
            UpdateLastModification();
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
            _rayTracer.OnFrameReady = _backgroundWorker.ReportProgress;
            _rayTracer.IsCancellationRequested = () => _backgroundWorker.CancellationPending;
            _rayTracer.Render(_scene, _camera);
        }

        private void BackgroundWorkerProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            (e.UserState as Texture)?.Blit();
            gLControl.SwapBuffers();
            (e.UserState as Texture)?.Dispose();
            Text = e.ProgressPercentage + "%";
        }

        private void InitializeBackgroundWorker()
        {
            _backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _backgroundWorker.DoWork += StartRender;
            _backgroundWorker.ProgressChanged += BackgroundWorkerProgressChanged;
        }

        private void newObjectButton_Click(object sender, EventArgs e)
        {
            var form = new NewObjectForm(new NewObjectController(_scene))
                {StartPosition = FormStartPosition.Manual, Location = Location + Size / 3};
            form.Show();
        }

        private void editObjectButton_Click(object sender, EventArgs e)
        {
            var form = new EditObjectForm(new EditObjectController(_scene, _scene.Models[0]))
                {StartPosition = FormStartPosition.Manual, Location = Location + Size / 3};
            form.Show();
        }
    }
}