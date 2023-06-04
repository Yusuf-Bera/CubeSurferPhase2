using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRandomizer : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject obstaclePart;

    public GameObject cubePrefab;

    //public GameObject road;
    //public GameObject roadPart;
    //public GameObject roadHalfPart;

    public int roadSize = 360;

    public void Start()
    {
        randomizer();
    }


    public void randomizer()
    {
        GameObject newObstacle;
        int obstaclePositionZ;

        int obstacleCount;

        for (obstaclePositionZ = 30; obstaclePositionZ < 520; obstaclePositionZ += 60)
        {
            obstacleCount = UnityEngine.Random.Range(1, 4);
                for (int i = 0; i < obstacleCount; i++)
                {
                    newObstacle = Instantiate(obstaclePrefab, new Vector3(-5, ((obstaclePart.GetComponent<Collider>().bounds.size.y + 2f) * i)-0.4f, obstaclePositionZ), Quaternion.Euler(new Vector3(0, 0, 0)));

                    if (i == obstacleCount - 1)
                    {
                        removePart(newObstacle);
                    }
                }
            
        }

        int cubePositionZ;

        int cubeCount;
        float cubeOffset;

        for (cubePositionZ = 20; cubePositionZ < 520; cubePositionZ += 30)
        {
            cubeCount = UnityEngine.Random.Range(1, 4);
            cubeOffset = UnityEngine.Random.Range(-5f, 5f);
            
                for (int i = 0; i < cubeCount; i++)
                {
                    Instantiate(cubePrefab, new Vector3(cubeOffset, ((cubePrefab.GetComponent<Collider>().bounds.size.y + 2f)*i), cubePositionZ), Quaternion.Euler(new Vector3(0, 0, 0)));
                }
            
        }
    }

    public void removePart(GameObject obstacle)
    {
        int count;
        int range;

        foreach (Transform child in obstacle.transform)
        {
            count = 0;
            range = UnityEngine.Random.Range(0, 4);

            while (count < range)
            {
                if (UnityEngine.Random.value > 0.5f)
                {
                    child.gameObject.SetActive(false);
                }

                count++;
            }
        }
    }
}
