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
using Newtonsoft.Json;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text;

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
        private CancellationTokenSource _cts;
        private Timer _fpsTimer = new Timer();
        private long lastModification;
        private bool rayTracingStarted;
        private bool _isUiUsed;

        private bool _automaticMode = true;
        private bool _manualModeCanRun = false;
        private bool ManualModeBlocked => !_automaticMode && _manualModeCanRun && rayTracingStarted;

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
            bool manualModeCanRun = !_automaticMode && _manualModeCanRun;
            if (manualModeCanRun) return true;
            return _automaticMode && !_isUiUsed && now - lastModification > SWAP_TIME;
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
            _scene.AddModel(new Cuboid()
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

            gLControl.KeyDown += GLControl_KeyDown;
        }

        private void GLControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (_automaticMode) return;
            if (e.KeyCode != Keys.R) return;
            if (_manualModeCanRun)
            {
                _manualModeCanRun = false;
                _cameraController.Blocked = false;
                UpdateLastModification();
            }
            else
            {
                _manualModeCanRun = true;
                _cameraController.Blocked = true;
            }
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
                    if (ManualModeBlocked)
                    {
                        this.FormBorderStyle = FormBorderStyle.FixedSingle;
                        this.MaximizeBox = false;
                        this.MinimizeBox = false;
                    }
                }
                else
                {
                    _renderer.Render(_scene, _cameraController.GetCamera());
                    gLControl.SwapBuffers();
                }

            if(!ManualModeBlocked)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MaximizeBox = true;
                this.MinimizeBox = true;
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
            if (ManualModeBlocked) return;
            var ray = _cameraController.GetCamera().GetRay(0.5f, 0.5f);
            var hitInfo = new HitInfo();
            var hit = _scene.HitTest(ray, ref hitInfo, 0.001f, float.PositiveInfinity);
            NewObjectFunction(hit, ref hitInfo);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            if (ManualModeBlocked) return;
            UpdateLastModification();
            _isUiUsed = true;

            var controller = new SettingsController(_camera, _rayTracer, _automaticMode);
            var form = new SettingsForm(controller)
                {StartPosition = FormStartPosition.Manual, Location = Location + Size / 3};

            form.Closed += FormOnClosed;
            form.Closed += (a, b) =>
            {
                _camera = controller.Camera;
                _cameraController?.Dispose();
                _cameraController = new CameraController(_camera, gLControl, UpdateLastModification);
                _rayTracer = controller.RayTracer;
                _automaticMode = controller.AutomaticMode;
                _manualModeCanRun = false;
                _cameraController.Blocked = false;
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
            if (ManualModeBlocked) return;
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
            if (ManualModeBlocked) return;
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
                    String.Format(Properties.Strings.DeleteMessage, model.ToString().ToLower());
                string caption = Properties.Strings.DeleteInfo;
               
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
            if (ManualModeBlocked) return;
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

        private void FormOnClosed(object sender, EventArgs e)
        {
            _isUiUsed = false;
            UpdateLastModification();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateLastModification();
        }

        private void saveSceneButton_Click(object sender, EventArgs e)
        {
            if (ManualModeBlocked) return;
            UpdateLastModification();
            _isUiUsed = true;
            SaveFileDialog saveDialog = new SaveFileDialog();
            DialogResult result = saveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String fileName = saveDialog.FileName;
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    ContractResolver = ShouldSerializeContractResolver.Instance
                };
                var json = JsonConvert.SerializeObject(_scene, settings);
                
                using (var output = File.Create(fileName))
                using (var gz = new GZipStream(output, CompressionMode.Compress))
                {
                    var bytes = Encoding.UTF8.GetBytes(json);
                    gz.Write(bytes);
                }
            }
            _isUiUsed = false;
        }

        private void loadSceneButton_Click(object sender, EventArgs e)
        {
            if (ManualModeBlocked) return;
            UpdateLastModification();
            _isUiUsed = true;
            OpenFileDialog loadDialog = new OpenFileDialog();
            DialogResult result = loadDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (var memoryStream = new MemoryStream())
                using (var input = loadDialog.OpenFile())
                using (var gz = new GZipStream(input, CompressionMode.Decompress))
                {
                    gz.CopyTo(memoryStream);
                    var bytes = memoryStream.ToArray();
                    var json = Encoding.Default.GetString(bytes);
                    var settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        ContractResolver = ShouldSerializeContractResolver.Instance
                    };
                    var scene = JsonConvert.DeserializeObject(json, typeof(Scene), settings);
                    _scene = scene as Scene;
                    foreach (var model in _scene.Models)
                    {
                        model.Load();
                    }
                    
                    _scene.Preprocess();
                    UpdateLastModification();
                }
            }
            _isUiUsed = false;
        }

        private void clearSceneButton_Click(object sender, EventArgs e)
        {
            if (ManualModeBlocked) return;
            var next = new Scene();
            next.AmbientLight = _scene.AmbientLight;
            _scene = next;
            UpdateLastModification();
        }
    }
}