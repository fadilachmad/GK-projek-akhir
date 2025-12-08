using UnityEngine;

public class ManualMovement : MonoBehaviour
{
    // Variabel publik agar bisa diedit di Inspector Unity
    public float speed = 5.0f;

    // Fungsi ini dipanggil sekali saat game mulai
    void Start()
    {
        Debug.Log("Game Dimulai!");
    }

    // Fungsi ini dipanggil SETIAP FRAME (seperti display loop di GLUT)
    void Update()
    {

        // 1. Ambil Input (Nilainya -1, 0, atau 1)
        // Horizontal = A/D atau Panah Kiri/Kanan
        // Vertical = W/S atau Panah Atas/Bawah
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // 2. Buat Vektor Arah (Direction)
        // Vector3 adalah tipe data struct (x, y, z)
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        // Normalisasi agar gerak diagonal tidak lebih cepat
        if (direction.magnitude > 1) direction.Normalize();

        // 3. TRANSFORMASI TRANSLASI MANUAL [Syarat Dokumen: 13, 16]
        // Rumus: Posisi Baru = Posisi Lama + (Arah * Kecepatan * Waktu Delta)
        // Time.deltaTime adalah waktu antara frame terakhir ke frame sekarang (agar gerakan halus)

        // JANGAN PAKAI: transform.Translate(direction); (DILARANG TUGAS)
        // PAKAI INI:
        transform.position = transform.position + (direction * speed * Time.deltaTime);

        // 4. TRANSFORMASI ROTASI MANUAL
        float rotationInput = 0;
        if (Input.GetKey(KeyCode.Q)) rotationInput = -1; // Putar kiri
        if (Input.GetKey(KeyCode.E)) rotationInput = 1;  // Putar kanan

        float rotationSpeed = 100.0f; // Derajat per detik

        // Rumus Rotasi Manual pada sumbu Y
        // Mengubah Euler Angles secara langsung
        Vector3 currentRotation = transform.rotation.eulerAngles;
        float newY = currentRotation.y + (rotationInput * rotationSpeed * Time.deltaTime);

        // Terapkan rotasi baru
        transform.rotation = Quaternion.Euler(currentRotation.x, newY, currentRotation.z);
    }
}