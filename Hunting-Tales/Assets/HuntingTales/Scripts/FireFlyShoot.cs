using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyShoot : MonoBehaviour
{
    [Header("Fireflies Shoot")]
    public Rigidbody bulletPrefab;
    public Transform shooter;
    public float speedShoot;
    public float timeShoot;
    private float startShoot;

    public BulletCount currentBullets;


    // Start is called before the first frame update
    void Start()
    {
        currentBullets = FindObjectOfType<BulletCount>();

        // amountBullets = amountBullets + 5
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > startShoot)

        {
            if (currentBullets.amountBullets > 0)
            {
                Rigidbody bulletPrefabInstance;

                startShoot = Time.time + timeShoot;

                bulletPrefabInstance = Instantiate(bulletPrefab, shooter.position, Quaternion.identity);
                bulletPrefabInstance.AddForce(shooter.forward * speedShoot * 100);
                // Destroy(bulletPrefab, 1);
                currentBullets.amountBullets = currentBullets.amountBullets - 1;

            }

        }
    }

    private void OnCollisionEnter(Collision other)
    {

    }
}
