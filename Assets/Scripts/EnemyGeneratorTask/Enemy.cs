using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject _object;

    public GameObject Object => _object;

    private void Awake()
    {
        _object = GetComponent<GameObject>();
    }
}