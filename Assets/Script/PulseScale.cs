using System;
using Unity.VisualScripting;
using UnityEngine;

public class PulseScale : MonoBehaviour
{
    [SerializeField] private float skalaMin = 0.8f;
    [SerializeField] private float skalaMaks = 1.2f;
    [SerializeField] private float kecepatan = 2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // nilai t bergerak halus antara 0 dan 1
        float t = (Mathf.Sin(Time.time * kecepatan) + 1f) * 0.5f;
        float s = Mathf.Lerp(skalaMin, skalaMaks, t);
        transform.localScale = new Vector3(s, s, 1f);


    }
}
