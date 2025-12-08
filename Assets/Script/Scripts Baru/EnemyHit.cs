using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private EnemyChase enemy;


    void Start()
    {
        enemy = transform.root.GetComponent<EnemyChase>();

    }

    void OnTriggerEnter(Collider other)
    {
        // Jika kena peluru
        if (other.GetComponent<BulletMove>() != null)
        {
            enemy.Die();
            Destroy(other.gameObject);
        }

        // Jika kena player
        if (other.CompareTag("Player"))
        {
            PlayerHealth hp = other.GetComponent<PlayerHealth>();
            if (hp != null)
            {
                hp.TakeDamage(10f);
            }
        }
    }
}
