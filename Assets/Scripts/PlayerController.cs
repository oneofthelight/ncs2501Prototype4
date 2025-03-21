using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float POWER_UP_TIME = 7.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerStrength = 10.0f;
    public float speed = 5.0f;
    public bool hasPowerup;
    public GameObject powerupIndicator;
    void Start()
    {
        powerupIndicator.gameObject.SetActive(false);
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("POWERUP"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdown());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ENEMY") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log($"Power up !! : {collision.gameObject.name}");
            enemyRb.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
        }
    }
    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(POWER_UP_TIME);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
