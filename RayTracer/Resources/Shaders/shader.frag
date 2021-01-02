#version 330 core
#define MAX_LIGHTS 5

struct Light
{
    vec3 position;

    vec3 diffuse;
};

out vec4 FragColor;

in vec2 texCoord;
in vec3 Normal;
in vec3 FragPos;

uniform int lightsCount;
uniform Light light[MAX_LIGHTS];
uniform vec3 ambientLight;

uniform vec3 materialColor;
uniform int singleColor;
uniform sampler2D texture0;
uniform int isLight;

vec3 CalcLight(Light light, vec3 normal, vec3 fragPos);

void main()
{
    vec4 color;
    if (singleColor == 0) {
        color = texture(texture0, texCoord);
    }
    else {
        color = vec4(materialColor, 1.0);
    }
    if (isLight != 0)
    {
        FragColor = color;
        return;
    }
    vec3 normal = normalize(Normal);
    vec3 lights = vec3(0.0, 0.0, 0.0);
    for (int i = 0; i < lightsCount; i++)
    {
        lights += CalcLight(light[i], normal, FragPos);
    }
    lights += ambientLight;
    FragColor = vec4(lights, 1.0) * color;
}

vec3 CalcLight(Light light, vec3 normal, vec3 fragPos)
{
    // diffuse shading
    vec3 lightDir = normalize(light.position - fragPos);
    float diff = max(dot(normal, lightDir), 0.0);
    vec3 diffuse = light.diffuse * diff;
    return diffuse;
}