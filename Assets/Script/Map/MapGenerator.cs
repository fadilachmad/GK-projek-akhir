using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] obstacles; // Array untuk menyimpan Prefab Batu & Pohon
    public int numberOfObjects = 30; // Berapa banyak objek yang mau dibuat
    public float mapSize = 20f; // Area sebaran (misal -20 sampai 20)

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        // 1. Tentukan Posisi Acak
        float randomX = Random.Range(-mapSize, mapSize);
        float randomZ = Random.Range(-mapSize, mapSize);
        Vector3 randomPos = new Vector3(randomX, 0.5f, randomZ);

        // 2. CEGAH TABRAKAN DENGAN PLAYER SAAT SPAWN
        // Jangan spawn di tengah-tengah (area 0,0,0) tempat Player muncul
        if (Vector3.Distance(randomPos, Vector3.zero) < 5.0f)
        {
            return; // Batalkan spawn ini jika terlalu dekat pemain
        }

        // 3. Pilih Prefab Acak (Batu atau Pohon)
        int randomIndex = Random.Range(0, obstacles.Length);
        GameObject selectedPrefab = obstacles[randomIndex];

        // 4. Rotasi Acak (Agar lebih alami)
        Quaternion randomRot = Quaternion.Euler(0, Random.Range(0, 360), 0);

        // 5. Instantiate
        Instantiate(selectedPrefab, randomPos, randomRot);
    }
}