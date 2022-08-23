using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float range;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    public IEnumerator Range()
    {
        yield return new WaitForSeconds(range);
        Destroy(gameObject);
    }
}
