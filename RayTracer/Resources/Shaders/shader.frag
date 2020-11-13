#version 330 core

in vec2 texCoord;
out vec4 FragColor;

void main()
{
    FragColor = vec4(texCoord, 0.0f, 0.0f);
}