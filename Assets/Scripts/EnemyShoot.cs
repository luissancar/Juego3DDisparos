using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject enemyBullet;
    public Transform spawnBulletPoint;

    private Transform playerPosition;
    public float bulletVelocity = 100;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = FindObjectOfType<PlayerMovement>().transform;
        Invoke("ShootPlayer", 3);
        
    }

    // Update is called once per frame
    void ShootPlayer()
    {
        if (playerPosition != null)
        {
            Vector3 playerDirection = playerPosition.position - transform.position;
            GameObject newBullet = Instantiate(enemyBullet, spawnBulletPoint.position,
                spawnBulletPoint.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity,
                ForceMode.Force);

            Invoke("ShootPlayer", 3);
        }
    }
}
