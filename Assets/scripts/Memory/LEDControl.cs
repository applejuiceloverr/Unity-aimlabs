using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDControl : MonoBehaviour
{
    public Material normalMaterial;
    public Material wrongMaterial;
    public float wrongDuration = 2f; 

    private Renderer[] ledRenderers;
        private MeshRenderer meshRenderer;


    void Awake()
    {
        
        ledRenderers = GetComponentsInChildren<Renderer>();
        SetNormal();
    }

    public void SetNormal()
    {
        foreach (var renderer in ledRenderers)
        {
            renderer.material = normalMaterial;
        }
    }

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

public IEnumerator SetWrong()
{
    foreach (var renderer in ledRenderers)
    {
        renderer.material = wrongMaterial;
    }

    yield return new WaitForSeconds(wrongDuration);

    foreach (var renderer in ledRenderers)
    {
        renderer.material = normalMaterial;
    }
}

    IEnumerator RevertColor()
    {
        yield return new WaitForSeconds(wrongDuration);
        SetNormal();
    }
}
