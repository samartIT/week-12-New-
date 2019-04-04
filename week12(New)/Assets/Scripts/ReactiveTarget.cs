using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    // Start is called before the first frame update

    public void ReacToHit() {
        StartCoroutine(Die());
    }

    IEnumerator Die() {
        transform.Rotate(-80, 0, 0);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
    