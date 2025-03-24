using System.Runtime.Serialization;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    private bool isCatched;
    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        isCatched = false;
    }

    private void Update()
    {
        Vector3 lookDirection= (player.transform.position - transform.position).normalized;
        if (!isCatched)
        {
            enemyRb.AddForce(lookDirection * speed);
        }
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MINE"))
        {
            enemyRb.Sleep();
            isCatched = true;
            other.GetComponent<Mine>().AddCatch();
        }
    }
}
