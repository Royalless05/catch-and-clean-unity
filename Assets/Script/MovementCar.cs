using UnityEngine.InputSystem;
using UnityEngine;

public class MovementCar : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 inputVector;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 720f;

    void Awake()
    {
        rb =  GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }


    void FixedUpdate()
    {
        if(inputVector.sqrMagnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputVector.y, inputVector.x) * Mathf.Rad2Deg - 90f;
            float currentAngle = rb.rotation;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(newAngle);
        }



        Debug.Log("Input: " + inputVector);

        Vector2 targetVelocity = inputVector * speed;

        rb.linearVelocity = targetVelocity;
    }
}
