using UnityEngine;

public class CollisionLogger : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 titik = collision.GetContact(0).point;
        Debug.Log(name + " Menabrak " + collision.gameObject.name + " di titik " + titik);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(name + " Lepas dari " + collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(name + " Masuk area " + other.name);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(name + " Keluar dari area " + other.name);
    }
}
