using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    Player player;
    public float damge;
    float dameRate = 0.5f;
    float nextDamage;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Start()
    {
        nextDamage = 0f;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x -= player.velocity.x * Time.fixedDeltaTime;

        if (pos.x < -100)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && nextDamage < Time.time)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.addDamage(damge);
            nextDamage = damge + Time.time;
            Debug.Log("damage!");
            slow(collision.transform);
        }


    }
    void slow(Transform transform)
    {

    }
}
