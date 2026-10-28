using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{

    [SerializeField] private float movSpeed = 2f; // unit perdetik
    [SerializeField] private float steerSpeed = 45f; // Derajat perdetik
    [SerializeField] private float skalaAwal = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        
    }

    void Start()
    {
        transform.localScale = new Vector3(skalaAwal, skalaAwal, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, steerSpeed * Time.deltaTime);
        transform.Translate(0f, movSpeed * Time.deltaTime, 0f);
            
    }
}
