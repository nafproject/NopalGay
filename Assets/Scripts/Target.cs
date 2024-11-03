using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private int health = 100; // Kesehatan awal

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Health remaining: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Logika saat objek mati (misalnya, hancurkan objek)
        Debug.Log(gameObject.name + " has died.");
        Destroy(gameObject); // Menghancurkan objek
    }
    private void Start()
    {
        Debug.Log(gameObject.name + " has Damageable component with health: " + health);
    }

}
