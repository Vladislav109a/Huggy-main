using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    float rotationSpeed = 100;

    private void Start()
    {
        rotationSpeed += Random.Range(0, rotationSpeed / 4.0f);
    }
    private void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
