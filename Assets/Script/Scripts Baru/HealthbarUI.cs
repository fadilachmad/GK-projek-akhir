using UnityEngine;
using UnityEngine.UI;

public class HealtbarUI : MonoBehaviour
{
    public float MaxHealth;
    public float Health;

    public float Width;
    public float Height;

    [SerializeField] private RectTransform healthbar;

    void Start()
    {
        // Ambil ukuran awal bar sebagai referensi
        Width = healthbar.sizeDelta.x;
        Height = healthbar.sizeDelta.y;
    }

    public void SetMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
        Health = maxHealth; // default full health
        UpdateBar();
    }

    public void SetHealth(float currentHealth)
    {
        Health = currentHealth;
        UpdateBar();
    }

    private void UpdateBar()
    {
        float newWidth = (Health / MaxHealth) * Width;
        healthbar.sizeDelta = new Vector2(newWidth, Height);
    }
}
