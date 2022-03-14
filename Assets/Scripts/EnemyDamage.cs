/*using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            //coliding with player takes one helath each time
            collision.GetComponent<Health>().TakeDamage(damage);
            //didnt have time for the player health
    }
}*/