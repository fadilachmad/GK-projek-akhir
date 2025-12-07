using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform playerTarget;
    public float speed = 3.0f;

    // Variabel logika mati
    private bool isDying = false;
    public float shrinkSpeed = 5.0f;

    // Variabel untuk akses warna (Shader)
    private Renderer enemyRenderer;

    void Start()
    {
        // 1. Ambil komponen Renderer saat game mulai
        //enemyRenderer = GetComponent<Renderer>();
        enemyRenderer = GetComponentInChildren<Renderer>();

        // 2. Cari Player otomatis jika belum diisi
        if (playerTarget == null)
        {
            GameObject p = GameObject.Find("Player");
            if (p != null) playerTarget = p.transform;
        }
    }

    // Fungsi Update berjalan setiap frame
    void Update()
    {
        // --- LOGIKA MUSUH MATI (SHRINK & WARNA) ---
        if (isDying)
        {
            // Ubah warna jadi MERAH (Pastikan nama "_MainColor" sesuai dengan Shader Graph)
            if (enemyRenderer != null)
            {
                enemyRenderer.material.SetColor("_MainColor", Color.red);
            }

            // Kecilkan ukuran (Transformasi Skala)
            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

            // Jika sudah sangat kecil, hapus musuh
            if (transform.localScale.x <= 0.05f)
            {
                Destroy(gameObject);
            }

            // PENTING: Return agar kode gerak di bawah tidak dijalankan saat mati
            return;
        }

        // --- LOGIKA GERAK MENGEJAR (Hanya jalan jika belum mati) ---
        if (playerTarget != null)
        {
            // Hitung arah
            Vector3 direction = playerTarget.position - transform.position;
            direction.Normalize();

            // Gerak (Translasi Manual)
            transform.position += direction * speed * Time.deltaTime;

            // Putar (Rotasi Manual)
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    } // <--- Tutup kurung Update di sini

    // Fungsi Deteksi Tabrakan
    void OnTriggerEnter(Collider other)
    {
        // Jika kena peluru
        if (other.GetComponent<BulletMove>() != null)
        {
            isDying = true; // Aktifkan status mati
            Destroy(other.gameObject); // Hancurkan peluru
        }
    }
} // <--- Tutup kurung Class di sini