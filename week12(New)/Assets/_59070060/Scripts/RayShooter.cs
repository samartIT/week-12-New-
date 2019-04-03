using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size/4;
        float posY = _camera.pixelHeight / 2 - size/2;  
        GUI.Label(new Rect(posX, posY, size, size), "*","red");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float posX = _camera.pixelWidth / 2;
            float posY = _camera.pixelHeight / 2;
            Vector3 point = new Vector3(posX, posY, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hiObject = hit.transform.gameObject;
                ReactiveTarget target = hiObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReacToHit();
                }
                else
                {
                    StartCoroutine(ShpereIndicator(hit.point));
                }
                
            }
        }
    }

    IEnumerator ShpereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
