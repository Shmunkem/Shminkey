using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRB;
    private GameObject Player;
    private float enemyDirection = 3;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * enemyDirection);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == Player) {
            Player.transform.position = new Vector3(0, -10, 0);
        }
        if (other.gameObject.CompareTag("PlayerAttack")) {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Obstacle")) {
            enemyDirection = enemyDirection * -1f;
        }
    }

}
