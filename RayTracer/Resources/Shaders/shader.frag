#version 330 core
#define MAX_LIGHTS 5
#define MATERIALS 3

struct Light
{
    vec3 position;

    vec3 diffuse;
};

struct Material
{
    float part;
    int useColor;
    vec3 color;
    sampler2D texture;
};

out vec4 FragColor;

in vec2 texCoord;
in vec3 Normal;
in vec3 FragPos;

uniform int lightsCount;
uniform Material materials[MATERIALS];
uniform Light light[MAX_LIGHTS];
uniform vec3 ambientLight;
uniform vec3 cameraPosition;
uniform float disturbance;

vec3 Phong();
vec4 GetMaterialColor(Material material);
float Attenuation(float dist);
vec4 Clamp(vec4 vec);
vec3 Clamp(vec3 vec);

void main()
{
    FragColor = vec4(Phong(), 1.0);
}

vec3 Phong() {
    vec4 ambient = Clamp(GetMaterialColor(materials[0]));
    vec4 diffuse = GetMaterialColor(materials[1]);
    vec4 specular = GetMaterialColor(materials[2]);

    vec3 normal = normalize(Normal);
    vec3 viewDirection = normalize(cameraPosition - vec3(FragPos));

    vec3 a = vec3(ambient), d = vec3(diffuse) * ambientLight, s = vec3(0);

    // Point lights
    for (int i = 0; i < lightsCount; i++) {
        float lightDistance = length(vec3(light[i].position) - FragPos);
        vec3 lightDir = normalize(light[i].position - FragPos);
        float diff = max(dot(normal, lightDir), 0.0);
        d += Clamp(light[i].diffuse) * diff * vec3(diffuse);
        vec3 reflectDir = reflect(-lightDir, normal);
        float reflectAngle = max(dot(reflectDir, viewDirection), 0);
        s += vec3(specular * pow(reflectAngle, 1 + (1-disturbance)*99));
    }

    return a * materials[0].part + d * materials[1].part + s * materials[2].part;
}

vec4 GetMaterialColor(Material material)
{
    return material.useColor == 1 ? vec4(material.color, 1.0) : texture(material.texture, texCoord);
}

float Attenuation(float dist)
{
    return 1 + 0.007 * dist + 0.0002 * dist * dist;
}

vec3 Clamp(vec3 vec) {
    return vec3(clamp(vec.x, 0, 1), clamp(vec.y, 0, 1), clamp(vec.z, 0, 1));
}

vec4 Clamp(vec4 vec) {
    return vec4(clamp(vec.x, 0, 1), clamp(vec.y, 0, 1), clamp(vec.z, 0, 1), clamp(vec.w, 0, 1));
}