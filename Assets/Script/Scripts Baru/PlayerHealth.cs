using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public bool isDead = false;
    public GameObject deathUI;



    public HealtbarUI healthUI;   // drag Healthbar UI kamu ke sini

    void Start()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return; // kalau sudah mati, abaikan damage

        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        healthUI.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Player is Dead!");

        // Berhenti bergerak
        Movement move = GetComponent<Movement>();
        if (move != null) move.enabled = false;

        PlayerCam cam = GetComponent<PlayerCam>();
        if (cam != null) cam.enabled = false;

        // Tampilkan UI Death
        if (deathUI != null)
            deathUI.SetActive(true);

        // Lock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


}
