using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{    void Update(){// Rotate the ship 360 degrees
        transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
    }
}
