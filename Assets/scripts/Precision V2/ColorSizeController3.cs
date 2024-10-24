using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSizeController3 : MonoBehaviour
{
    public Color originalColor = Color.white;
    public Color colorTwo = Color.red;
    public float colorChangeRate = 1.0f;

    private Renderer sphereRenderer;
    private bool isOriginalColor = true;

    void Start()
    {
        sphereRenderer = GetComponent<Renderer>();
        sphereRenderer.material.color = originalColor; 
        InvokeRepeating("ChangeColor", 0f, colorChangeRate);
    }

    void ChangeColor()
    {
        isOriginalColor = !isOriginalColor;
        sphereRenderer.material.color = isOriginalColor ? originalColor : colorTwo;
    }

    public bool IsOriginalColor()
    {
        return isOriginalColor;
    }
}