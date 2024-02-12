using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private int _count;

    private List<GameObject> _cubeList = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SpawnObject(_count);
       

        if (Input.GetKeyDown((KeyCode.R)))
        {
            foreach (var cube in _cubeList) Destroy(cube);
        }
    }

    private void SpawnObject(int count)
    {
        for (int i = 1; i < count; i++)
        {
            var cube = Instantiate(_object);
            cube.transform.position = new Vector3(Random.Range(-5f, 5f), 10f, Random.Range(-5f, 5f));
            _cubeList.Add(cube);
        }
    }
}