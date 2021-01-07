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
using RayTracing.Models;
using RayTracing.Sampling;
using RayTracing.World;
using Camera = RayTracing.Cameras.Camera;
using Timer = System.Windows.Forms.Timer;
using Color = RayTracing.Maths.Color;
using RayTracerApp.SceneController;
using System.Threading;

namespace RayTracerApp.Forms
{
    public partial class MainForm : Form
    {
        private const int SWAP_TIME = 2;
        private Scene _scene = new Scene();
        private IRenderer _renderer;
        private Camera _camera = new LensCamera(new Vector3(0, 0, 20)) {AspectRatio = 1, AutoFocus = true};
        private CameraController _cameraController;
        private IncrementalRayTracer _rayTracer;
        private BackgroundWorker _backgroundWorker;
        private CancellationTokenSource _cts;
        private Timer _fpsTimer = new Timer();
        private long lastModification;
        private bool rayTracingStarted;
        private bool _isUiUsed;

        private HitInfo _contextHitInfo;
        private bool _contextHit;

        private Texture _lastTexture;

        public void UpdateLastModification()
        {
            lastModification = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
            rayTracingStarted = false;
            _backgroundWorker?.CancelAsync();
            _cts?.Cancel();
        }

        public bool ShouldRaytrace()
        {
            long now = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
            return !_isUiUsed && now - lastModification > SWAP_TIME;
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
            _rayTracer = new SamplesRayTracer(8, 1000, Vec2Sampling.Jittered, gLControl.Width, 10);
            _cameraController = new CameraController(_camera, gLControl, UpdateLastModification);
            _scene.AmbientLight = new AmbientLight {Color = Color.FromColor4(Color4.LightSkyBlue)};
            _scene.AddModel(new Sphere
            {
                Position = new Vector3(0, 5.5f, 0), Scale = 1,
                Material = new MasterMaterial(new Emissive(Color.FromColor4(Color4.LightYellow), 25))
            }.Load());
            _scene.AddModel(new Sphere
            {
                Position = new Vector3(-2.5f, 0.5f, 1), Scale = 1,
                Material = new MasterMaterial(new Reflective(Color.FromColor4(Color4.Azure), 0.1f))
            }.Load());
            _scene.AddModel(new Sphere
            {
                Position = new Vector3(2.5f, 0.5f, 1), Scale = 1,
                Material = new MasterMaterial(new Diffuse(new Texture("earthmap.jpg")))
            }.Load());
            _scene.AddModel(new Cylinder(2)
            {
                Position = new Vector3(5f, 0.5f, 0), Scale = 1,
                Material = new MasterMaterial(new Diffuse(Color.FromColor4(Color4.Chocolate)))
            }.Load());
            _scene.AddModel(new Cylinder(2)
            {
                Position = new Vector3(5f, 0.5f, 4), Scale = 1,
                Material = new MasterMaterial(new Diffuse(new Texture("wood.jpg"))),
                Rotation = Vector3.One * (float) Math.PI / 3
            }.Load());
            _scene.AddModel(new Cube()
            {
                Position = new Vector3(0, 0.5f, -3), Scale = 1,
                Material = new MasterMaterial(new Diffuse(new Texture("wood.jpg")))
            }.Load());
            _scene.AddModel(new Rectangle(2)
            {
                Position = new Vector3(0, 0.5f, -1.99f), Scale = 0.8f,
                Material = new MasterMaterial(new Emissive(Color.FromColor4(Color4.White) * 8)),
                Rotation = new Vector3((float) Math.PI / 2, 0, 0)
            }.Load());
            _scene.AddModel(new Plane
            {
                Position = new Vector3(0, -0.5f, 0), Scale = 1,
                Material = new MasterMaterial(new Diffuse(Color.FromColor4(Color4.Green)),
                    new Reflective(Color.FromColor4(Color4.White), 0.1f),
                    new Refractive(Color.FromColor4(Color4.Green), 1))
                {
                    Parts = (0.0f, 0.8f, 0.1f, 0.0f)
                }
            }.Load());
            _scene.Preprocess();
            InitializeFpsTimer();
            UpdateViewport();

            gLControl.MouseClick += GLControl_MouseClick;
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
                    progressBar.Value = 0;
                    progressBar.Visible = true;
                    rayTracingStarted = true;
                }
                else
                {
                    _renderer.Render(_scene, _cameraController.GetCamera());
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
            _cameraController.GetCamera().AspectRatio = gLControl.Width / (float) gLControl.Height;
            gLControl.Invalidate();
            _rayTracer.Resolution = gLControl.Width;
            _lastTexture = new Texture(Width, Height);
        }

        private void StartRender(object sender, DoWorkEventArgs e)
        {
            _rayTracer.OnFrameReady = _backgroundWorker.ReportProgress;
            _rayTracer.CancellationToken = _cts.Token;
            _rayTracer.Render(_scene, _cameraController.GetCamera());
        }

        private void BackgroundWorkerProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            var texture = (Texture) e.UserState;
            texture?.Blit();
            if (!gLControl.IsDisposed)
                gLControl.SwapBuffers();
            _lastTexture?.CopyFrom(texture);
            texture?.Dispose();
            progressBar.Value = e.ProgressPercentage;
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
            _backgroundWorker.RunWorkerCompleted += (o, args) =>
            {
                progressBar.Visible = false;
                if (!gLControl.IsDisposed)
                    gLControl.SwapBuffers();
            };
            _cts = new CancellationTokenSource();
        }

        private void newObjectButton_Click(object sender, EventArgs e)
        {
            var ray = _cameraController.GetCamera().GetRay(0.5f, 0.5f);
            var hitInfo = new HitInfo();
            var hit = _scene.HitTest(ray, ref hitInfo, 0.001f, float.PositiveInfinity);
            NewObjectFunction(hit, ref hitInfo);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            UpdateLastModification();
            _isUiUsed = true;

            var controller = new SettingsController(_camera, _rayTracer);
            var form = new SettingsForm(controller)
                {StartPosition = FormStartPosition.Manual, Location = Location + Size / 3};

            form.Closed += FormOnClosed;
            form.Closed += (a, b) =>
            {
                _camera = controller.Camera;
                _cameraController = new CameraController(_camera, gLControl, UpdateLastModification);
                _rayTracer = controller.RayTracer;
            };
            form.Show();
        }

        private void NewObjectFunction(bool hit, ref HitInfo hitInfo)
        {
            UpdateLastModification();
            var sphere = new Sphere().Load();
            _isUiUsed = true;
            if (hit && hitInfo.Distance < 50)
            {
                sphere.Position = hitInfo.HitPoint;
            }
            else
            {
                sphere.Position = _camera.Position + _camera.Front.Normalized() * 4;
            }

            _scene.AddModel(sphere);
            var form = new NewObjectForm(new ObjectController(_scene, sphere))
                {StartPosition = FormStartPosition.Manual, Location = Location + Size / 3};
            _isUiUsed = true;
            form.Closed += FormOnClosed;
            form.Show();
        }

        private void editObjectButton_Click(object sender, EventArgs e)
        {
            var ray = _cameraController.GetCamera().GetRay(0.5f, 0.5f);
            var hitInfo = new HitInfo();
            var hit = _scene.HitTest(ray, ref hitInfo, 0.001f, float.PositiveInfinity);
            EditObjectFunction(hit, ref hitInfo);
        }

        private void EditObjectFunction(bool hit, ref HitInfo hitInfo)
        {
            UpdateLastModification();
            _isUiUsed = true;
            if (hit)
            {
                var model = hitInfo.ModelHit;
                if (model is Triangle triangle) model = triangle.Parent;
                var form = new EditObjectForm(new ObjectController(_scene, model))
                    {StartPosition = FormStartPosition.Manual, Location = Location + Size / 3};
                form.Closed += FormOnClosed;
                form.Show();
            }
            else
            {
                ColorDialog MyDialog = new ColorDialog();
                MyDialog.AllowFullOpen = true;
                MyDialog.Color = _scene.AmbientLight.Color.ToSystemDrawing();

                if (MyDialog.ShowDialog() == DialogResult.OK)
                {
                    _scene.AmbientLight.Color = Color.FromSystemDrawing(MyDialog.Color);
                }

                _isUiUsed = false;
                UpdateLastModification();
            }
        }

        private void deleteObjectButton_Click(object sender, EventArgs e)
        {
            var ray = _cameraController.GetCamera().GetRay(0.5f, 0.5f);
            var hitInfo = new HitInfo();
            var hit = _scene.HitTest(ray, ref hitInfo, 0.001f, float.PositiveInfinity);
            DeleteObjectFunction(hit, ref hitInfo);
        }

        private void DeleteObjectFunction(bool hit, ref HitInfo hitInfo)
        {
            UpdateLastModification();
            _isUiUsed = true;
            if (hit)
            {
                var model = hitInfo.ModelHit;
                if (model is Triangle triangle) model = triangle.Parent;
                string message =
                    $"Are you sure that you would like to delete the {model}?";
                const string caption = "Delete object";
                var result = MessageBox.Show(message, caption,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _scene.Models.Remove(model);
                    _scene.Preprocess();
                }
            }

            _isUiUsed = false;
        }

        private void GLControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var width = (float) gLControl.Width;
                var height = (float) gLControl.Height;
                var u = e.X / width;
                var v = 1 - e.Y / height;
                var ray = _cameraController.GetCamera().GetRay(u, v);
                _contextHitInfo = new HitInfo();
                _contextHit = _scene.HitTest(ray, ref _contextHitInfo, 0.001f, float.PositiveInfinity);

                if (_contextHit)
                {
                    newDeleteStrip.Show(Cursor.Position);
                }
                else
                {
                    newEditStrip.Show(Cursor.Position);
                }
            }
        }

        private void SaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            DialogResult result = saveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String fileName = saveDialog.FileName;
                _lastTexture.Write(fileName);
            }
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            DeleteObjectFunction(_contextHit, ref _contextHitInfo);
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            EditObjectFunction(_contextHit, ref _contextHitInfo);
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            NewObjectFunction(_contextHit, ref _contextHitInfo);
        }

        private void FormOnClosed(object? sender, EventArgs e)
        {
            _isUiUsed = false;
            UpdateLastModification();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateLastModification();
        }
    }
}