using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; // Titik keluar peluru (moncong senjata)

    void Update()
    {
        // Input Trigger Pengguna (Klik Kiri atau Spasi) [Syarat: 11]
        // "Fire1" biasanya dipetakan ke Klik Kiri Mouse atau Ctrl Kiri
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Spawn peluru sesuai posisi & rotasi pemain saat ini
        if (bulletPrefab != null)
        {
            // Instantiate(Objek, Posisi, Rotasi)
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}