using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public Material material; // Material yang menggunakan Shader Graph
    public float startValue = 0f; // Nilai awal DissolveStrength
    public float incrementPerSecond = 0.1f; // Nilai penambahan per detik
    private float currentValue;

    void Start()
    {
        currentValue = startValue;
        if (material == null)
        {
            Debug.LogError("Material tidak terpasang!");
        }
    }

    void Update()
    {
        if (material != null)
        {
            currentValue += incrementPerSecond * Time.deltaTime;
            material.SetFloat("_DissolveStrength", currentValue);
            Debug.Log("DissolveStrength: " + currentValue);
        }
    }
}
