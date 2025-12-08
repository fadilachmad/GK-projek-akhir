using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Tempat kita menaruh cetakan musuh
    public float spawnInterval = 2.0f; // Muncul setiap 2 detik
    private float timer = 0f;

    void Update()
    {
        // Hitung waktu mundur
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f; // Reset timer
        }
    }

    void SpawnEnemy()
    {
        // Tentukan posisi muncul acak (Procedural)
        // Misal: Random antara -10 sampai 10 di sumbu X dan Z
        float randomX = Random.Range(-10f, 10f);
        float randomZ = Random.Range(-10f, 10f);

        // Kita spawn agak jauh dari tengah agar tidak langsung menabrak player
        // Logika sederhana: kalau terlalu dekat (0), geser ke 10
        if (Mathf.Abs(randomX) < 5) randomX += 10;

        Vector3 spawnPos = new Vector3(randomX, 0f, randomZ);

        // FITUR UNITY: Instantiate (Membuat objek dari Prefab)
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}