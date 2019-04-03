using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    int damage = 1;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerCharactor player = other.GetComponent<PlayerCharactor>();
        if (player != null)
        {
            //Debug.Log("Player hit");
            player.Hurt(damage);
        }
        Destroy(gameObject);
    }
}
