using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonderingAI : MonoBehaviour
{
    public float speed = 3f, obstacleRange = 5f;
    private bool _alive;
    private GameObject _fireball;
    [SerializeField] private GameObject fireballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerChatactor>())
            {
                if (_fireball == null)
                {
                    _fireball = Instantiate(fireballPrefab) as GameObject;
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            } else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-100, 100);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    public void setAlive(bool aliveState)
    {
        _alive = aliveState;
    }
}
