#version 330 core
layout (location = 0) in vec3 aPosition;
layout (location = 2) in vec2 aTexCoord;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

out vec2 texCoord;
void main()
{
    texCoord = aTexCoord;
    mat4 vp = view * projection;
    gl_Position = vec4(aPosition, 1.0) * model * vp ;
}