using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSeta : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    void Update()
    {
        transform.LookAt(playerPosition);
    }
}
