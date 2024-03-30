﻿#version 330 core

in vec3 vColor;
in vec2 vUv;
in vec4 vNormal;
in vec4 fragPosition;

out vec4 outputColor;

uniform sampler2D texture0;

uniform vec3 lightPosition;
uniform vec3 lightDirection;
uniform vec3 lightColor;
uniform float lightIntensity;
uniform vec3 ambientColor;
uniform float ambientIntensity;
uniform vec3 viewPosition;

float LambertTerm(vec3 LightDirection, vec3 NormalDirection)
{
    return max(dot(NormalDirection, LightDirection), 0.0);
}

void main()
{
    vec3 lightDir = normalize(lightPosition - fragPosition.xyz);
    vec3 normalDir = normalize(vNormal.xyz);

    vec3 diffuseLight = vec3(LambertTerm(lightDir, normalDir)) * (lightColor * lightIntensity);

    vec3 ambientLight = ambientColor * ambientIntensity;

    vec3 textureColor = texture(texture0, vUv).xyz;

    vec3 finalLight = (diffuseLight + ambientLight) * textureColor;

    outputColor = vec4(finalLight, 1.0);
}