using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    int damage = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
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
