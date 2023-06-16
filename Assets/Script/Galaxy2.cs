using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy2 : MonoBehaviour
{
    public GameObject moon;

    private void Update()
    {
        transform.Rotate(Vector3.up * 360f * Time.deltaTime);

        moon.transform.RotateAround(transform.position, Vector3.up, 10 * Time.deltaTime);
    }
}
