using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinGenerator : MonoBehaviour
{
    [Tooltip("Resolution width")]
    [SerializeField, Range(1, 4000)]
    int _width = 256;
    [Tooltip("Resolution height")]
    [SerializeField, Range(1, 4000)]
    int _height = 256;
    //the higher the darker
    [SerializeField, Range(0.0f, 100.0f)]
    float perlinNoiseIntensity = 1f;
    [SerializeField, Range(0.1f, 0.9f)]
    float perlinNoiseOffsetX = 0.35f;
    [SerializeField, Range(0.1f, 0.9f)]
    float perlinNoiseOffsetY = 0.35f;
    //the higher the bigger
    [SerializeField, Range(1.0f, 100f)]
    float perlinNoiseScale;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {

        rend.material.mainTexture = CreateTexture(_width, _height);
    }

    private Texture2D CreateTexture(int width, int height)
    {
        Texture2D tex = new Texture2D(width, height);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = GenerateColor(x, y);
                tex.SetPixel(x, y, color);
            }
        }
        tex.Apply();
        return tex;
    }

    private Color GenerateColor(int x, int y)
    {
        float perlinNoise = Mathf.PerlinNoise((x * perlinNoiseOffsetX) / perlinNoiseScale, (y * perlinNoiseOffsetY) /perlinNoiseScale) / perlinNoiseIntensity;
        return new Color(perlinNoise, perlinNoise, perlinNoise);
    }
}
