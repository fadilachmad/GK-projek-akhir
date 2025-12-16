using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform playerTarget;
    public float speed = 3.0f;

    private bool isDying = false;
    public float shrinkSpeed = 5.0f;

    Rigidbody rb;
    private Renderer enemyRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyRenderer = GetComponentInChildren<Renderer>();

        if (playerTarget == null)
        {
            GameObject p = GameObject.Find("Player");
            if (p != null) playerTarget = p.transform;
        }

        rb.freezeRotation = true;
    }

    void Update()
    {
        if (isDying)
        {
            if (enemyRenderer != null)
                enemyRenderer.material.SetColor("_MainColor", Color.red);

            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

            if (transform.localScale.x <= 0.05f)
                Destroy(gameObject);

            return;
        }

        if (playerTarget != null)
        {
            Vector3 direction = (playerTarget.position - transform.position).normalized;

            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);

            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }

    public void Die()
    {
        if (isDying) return;

        isDying = true;

        // Mainkan sound effect serigala mati
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayWolfDeathSFX();
        }

        // Tambahkan poin ke pemain
        ScoreManager.instance.AddScore(10);

        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;
    }

}
