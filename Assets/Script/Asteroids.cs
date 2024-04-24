using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public Transform planeta;

    void Update()
    {
        Quaternion rotacion = Quaternion.Euler(0.2f, 0, 0);

        Vector3 posicionRelativa = rotacion * (transform.position - planeta.position);

        transform.position = planeta.position + posicionRelativa;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
