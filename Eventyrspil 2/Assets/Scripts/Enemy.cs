using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ushort health;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;

    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(-1, 0) * acceleration, ForceMode2D.Force);

        if(rb.velocity.magnitude > maxSpeed) rb.velocity = new Vector2(-maxSpeed, 0);
    }

    public void TakeDamage(ushort damage)
    {
        Debug.Log($"HEALTH 1:  {health}");

        health -= damage;

        Debug.Log($"HEALTH 2:  {health}");

        if (health <= 0) Destroy(gameObject);
    }
}
