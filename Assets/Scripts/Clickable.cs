using System.Collections;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField] private Reticle reticleManager;
    [SerializeField] private float shootCooldown = 1.0f; // Waktu jeda antar tembakan
    [SerializeField] private LayerMask damageableLayer;
    private bool canShoot = true;

    // Variabel baru untuk menyimpan damage yang akan diberikan
    [SerializeField] private int damage = 10;

    private void OnMouseDown()
    {
        if (canShoot)
        {
            reticleManager.Selected(this.gameObject);
        }
    }

    private void OnMouseUp()
    {
        if (canShoot)
        {
            reticleManager.Deselect();
            StartCoroutine(ShootCooldown()); // Mulai jeda antar tembakan
            FireDamage(); // Memanggil fungsi untuk memberikan damage
        }
    }

    private void FireDamage()
    {
        float detectionRadius = 10f; // Radius deteksi, dapat diubah sesuai kebutuhan
        Collider2D hit = Physics2D.OverlapCircle(transform.position, detectionRadius);

        if (hit != null)
        {
            Debug.Log("Hit object: " + hit.gameObject.name); // Menampilkan nama objek yang terdeteksi
            Damageable target = hit.GetComponent<Damageable>();

            if (target != null)
            {
                target.TakeDamage(damage); // Berikan damage jika objek memiliki komponen Damageable
                Debug.Log("Damage dealt to target: " + damage);
            }
            else
            {
                Debug.Log("Hit object does not have Damageable component: " + hit.gameObject.name);
            }
        }
        else
        {
            Debug.Log("No target hit within detection radius.");
        }
    }




    private IEnumerator ShootCooldown()
    {
        canShoot = false; // Mencegah tembakan baru
        yield return new WaitForSeconds(shootCooldown); // Tunggu sesuai waktu jeda
        canShoot = true; // Izinkan tembakan baru setelah jeda selesai
    }
}
