using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningOrb : MonoBehaviour
{
    float speed = 3;

    void Update()
    {
        transform.position += transform.rotation * Vector3.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
