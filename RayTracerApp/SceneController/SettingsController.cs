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

        public SettingsController(Camera camera, IncrementalRayTracer rayTracer)
        {
            Camera = camera;
            RayTracer = rayTracer;
        }
    }
}
