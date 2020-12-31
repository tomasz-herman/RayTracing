#version 330 core

struct Light
{
    vec3 position;
    
    vec3 diffuse;
};

out vec4 FragColor;

in vec2 texCoord;
in vec3 Normal;
in vec3 FragPos;

uniform Light light;
uniform vec3 ambientLight;

uniform vec3 materialColor;
uniform int singleColor;
uniform sampler2D texture0;

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
    vec3 normal = normalize(Normal);
    vec3 lights = CalcLight(light, normal, FragPos);
    
    FragColor = vec4(ambientLight+lights, 1.0) * color;
}

vec3 CalcLight(Light light, vec3 normal, vec3 fragPos)
{
    // diffuse shading
    vec3 lightDir = normalize(light.position - fragPos);
    float diff = max(dot(normal, lightDir), 0.0);
    vec3 diffuse = light.diffuse * diff;
    return diffuse;
}