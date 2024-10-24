using UnityEngine;
using System.Collections.Generic;
public class ColorSizeController : MonoBehaviour
{
    public Color colorOne;
    public Color colorTwo;
    public float colorChangeRate = 0.5f;
    public float shrinkRate = 0.1f;
    public float minSize = 0.5f;

    private Renderer sphereRenderer;
    private bool isColorOne = true;
    private Vector3 originalScale;

  public void Start()
    {
        sphereRenderer = GetComponent<Renderer>();
        originalScale = transform.localScale;
        InvokeRepeating("ChangeColor", 0f, colorChangeRate);
    }

    public void ChangeColor()
    {
        isColorOne = !isColorOne;
        sphereRenderer.material.color = isColorOne ? colorOne : colorTwo;
    }

public void Hit()
{
    if (transform.localScale.x > minSize)
    {
        transform.localScale -= Vector3.one * shrinkRate;
        Debug.Log("Reducing size: " + transform.localScale); // Add this line
    }
}


    public void ResetSize()
    {
        transform.localScale = originalScale;
    }

    public bool IsColorOne()
    {
        return isColorOne;
    }
}
