using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Thrower : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;
    bool readyToThrow;

    // Tambahan: reference ke PlayerHealth
    private PlayerHealth playerHealth;

    private void Start()
    {
        readyToThrow = true;

        // cari component PlayerHealth di objek player ini
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        // ➤ Cegah tembak kalau player sudah mati
        if (playerHealth != null && playerHealth.isDead)
            return;

        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        projectile.transform.Rotate(90, 0, 0);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd =
            cam.transform.forward * throwForce +
            transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
