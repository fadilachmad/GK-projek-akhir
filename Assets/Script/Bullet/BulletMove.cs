using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 3f; // Peluru hilang setelah 3 detik agar tidak menumpuk memori

    void Start()
    {
        // Hancurkan diri sendiri setelah sekian detik (Cleanup)
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // TRANSLASI MANUAL: Bergerak ke arah "Forward" (Depan relatif objek)
        // transform.forward adalah vektor arah depan lokal objek
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    // Fungsi bawaan Unity untuk mendeteksi tabrakan (akan dipakai di tahap selanjutnya)
    void OnTriggerEnter(Collider other)
    {
        // Jika menabrak sesuatu bernama "Enemy", hancurkan peluru ini
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}