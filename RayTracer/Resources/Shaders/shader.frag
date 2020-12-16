#version 330 core

in vec2 texCoord;
out vec4 FragColor;

void main()
{
    FragColor = vec4(0.0f, texCoord, 0.0f);
}