#version 330 core

out vec4 FragColor;

in vec2 texCoord;
in vec3 Normal;
in vec3 FragPos;

uniform vec3 ambientLight;
uniform vec3 materialColor;
uniform int singleColor;
uniform sampler2D texture0;

void main()
{
    vec4 color;
    if (singleColor == 0) {
        color = texture(texture0, texCoord);
    }
    else {
        color = vec4(materialColor, 1.0);
    }
    FragColor = vec4(ambientLight, 1.0) * color;
}