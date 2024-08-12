using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private int speed = 10;
    private int minForce = 13;
    private int maxForce = 18;
    private int xMaxPosition = 4;
    private int yMaxPosition = 6;

    private GameManager gameManager;
    public ParticleSystem explosion_ps;

    public int pointValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = GetSpawnPosition();
    }

    //private void OnMouseDown()
    //{
    //    if (gameManager.isGameActive == true)
    //    {
    //        DestroyTarget();
    //    }
    //}
    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.AddPoint(pointValue);
            Instantiate(explosion_ps, 
                gameObject.transform.position, 
                explosion_ps.transform.rotation);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Bad") == false && gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateLives(-1);

            //gameManager.GameOver();
            //gameManager.isGameActive = false;
        }
    }
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    private int RandomTorque()
    {
        return Random.Range(-speed, speed);
    }

    private Vector3 GetSpawnPosition()
    {
        return new Vector3(Random.Range(-xMaxPosition, xMaxPosition), -yMaxPosition);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
