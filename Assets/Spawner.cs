using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public Action NeedToDestroy;
    [SerializeField] private GameObject _object;
    [SerializeField] private int _count;

    private List<GameObject> _cubeList = new List<GameObject>();

    void Update()
    {
        SpawnObject(_count);

        var pingPong = Mathf.PingPong(3f, 6f);
        Debug.Log(pingPong);


        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (var cube in _cubeList)
            {
                NeedToDestroy.Invoke();
            }
        }
    }

    private void SpawnObject(int count)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < count - 1; i++)
            {
                var cube = Instantiate(_object);
                cube.transform.position = new Vector3(Random.Range(-5f, 5f), 10f, Random.Range(-5f, 5f));
                _cubeList.Add(cube);
            }
        }
    }
}