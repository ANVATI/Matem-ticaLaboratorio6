using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    public float WorldRotation = 20f;

    void Update()
    {
        this.transform.Rotate(new Vector3(WorldRotation, 0, 0) * Time.deltaTime);
    }

}
