using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public AudioClip shootSound;
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ShootNearest();
        }
    }
    public void ShootNearest()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0) return;

        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Vector3 direction = nearestEnemy.transform.position - transform.position;
            bullet.transform.up = direction;

            if (shootSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
        }
    }
}
