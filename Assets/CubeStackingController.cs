using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStackingController : MonoBehaviour
{
    public float stackHeight = 2f; // K�plerin y�ksekli�i
    public float stackOffset = 0.1f; // K�pler aras�ndaki bo�luk

    private List<GameObject> cubeStack = new List<GameObject>(); // K�plerin listesi
    private float currentStackHeight = 0f; // Mevcut y���nlama y�ksekli�i

    private HeroMovementController heroMovement; // HeroMovementController referans�

    private void Start()
    {
        heroMovement = FindObjectOfType<HeroMovementController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cube"))
        {
            GameObject cube = other.gameObject;

            if (cubeStack.Count == 0)
            {
                // �lk k�p� do�rudan y���na ekle
                AddToStack(cube);
            }
            else
            {
                // Y���n� dengelemek i�in kontrol yap
                bool isBalanced = CheckBalance(cube);

                if (isBalanced)
                {
                    // K�p� y���na ekle
                    AddToStack(cube);
                }
                else
                {
                    // Y���ndan ��kar ve oyunu bitir
                    RemoveFromStack(cube);
                }
            }
        }
    }

    public void AddToStack(GameObject cube)
    {
        Vector3 stackPosition = transform.position + Vector3.up * currentStackHeight;
        cube.transform.position = stackPosition;
        cubeStack.Add(cube);

        currentStackHeight += stackHeight + stackOffset;
    }

    private bool CheckBalance(GameObject cube)
    {
        int stackCount = cubeStack.Count;

        if (stackCount > 0)
        {
            GameObject topCube = cubeStack[stackCount - 1];
            float topCubeHeight = topCube.transform.position.y;
            float currentCubeHeight = cube.transform.position.y;

            float heightDifference = currentCubeHeight - topCubeHeight;

            if (Mathf.Approximately(heightDifference, stackHeight))
            {
                return true; // K�p dengeli
            }
        }

        return false; // K�p dengesiz
    }

    public void RemoveFromStack(GameObject cube)
    {
        cubeStack.Remove(cube);
        Destroy(cube);

        currentStackHeight -= stackHeight + stackOffset;
    }
}
