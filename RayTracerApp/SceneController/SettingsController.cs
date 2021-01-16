using RayTracing;
using RayTracing.Cameras;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerApp.SceneController
{
    public class SettingsController
    {
        public Camera Camera { get; set; }
        public IncrementalRayTracer RayTracer { get; set; }

        public bool AutomaticMode { get; set; }

        public SettingsController(Camera camera, IncrementalRayTracer rayTracer, bool mode)
        {
            Camera = camera;
            RayTracer = rayTracer;
            AutomaticMode = mode;
        }
    }
}
