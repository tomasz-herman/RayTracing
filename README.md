# RayTracing

Program visualising creation of a realistic scene using ray tracing.

### Projects

##### RayTracer
Library providing tools for OpenGL and ray tracing scene rendering.

##### RayTracerApp
Project combining the interface and communication with the RayTracer library. 
The interface is written in WinForms.
When you're moving, the scene is rendered using OpenGL. 
Once you stop moving, the scene starts to be rendered using ray tracing and you can observe the gradually generated realistic scene.

##### RayTracerDemo
Project rendering a scene using ray tracing and writing the generated image to the file.

##### RayTracerTests
Tests

### Prerequisites 
- .NET Core 3.1
- RayTracerApp needs to be compiled under Windows 10. Rest of the projects work under Linux too.

### Build the project

To build the application do the following steps:

- Make sure to be in the root directory of the project
- Run the command:
```
dotnet build --configuration Release
```