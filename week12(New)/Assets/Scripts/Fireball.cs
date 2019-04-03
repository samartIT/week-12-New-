using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    int damage = 1;
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        PlayerCharactor player = other.GetComponent<PlayerCharactor>();
        if (player != null)
        {
            Debug.Log("Player hit");
        }
        Destroy(gameObject);
    }
}
