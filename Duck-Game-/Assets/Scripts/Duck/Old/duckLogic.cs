using UnityEngine;
using System.Collections;

public class duckLogic : MonoBehaviour
{
    public Vector3 MoveVector = Vector3.up;
    public float MoveRange = .75f;
    public float MoveSpeed = 3;
    Vector3 startPosition;
    public static bool move = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position = startPosition + MoveVector * (MoveRange * Mathf.Sin(Time.time * MoveSpeed));
    }

    



}

