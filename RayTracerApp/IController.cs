using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerApp
{
    public interface IController : IDisposable
    {
        void SetModel(Model model);
        Model GetModel();
        void DeleteModel();
    }
}
