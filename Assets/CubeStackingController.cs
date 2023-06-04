using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStackingController : MonoBehaviour
{
    public float stackHeight = 2f; // Küplerin yüksekliði
    public float stackOffset = 0.1f; // Küpler arasýndaki boþluk

    private List<GameObject> cubeStack = new List<GameObject>(); // Küplerin listesi
    private float currentStackHeight = 0f; // Mevcut yýðýnlama yüksekliði

    private HeroMovementController heroMovement; // HeroMovementController referansý

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
                // Ýlk küpü doðrudan yýðýna ekle
                AddToStack(cube);
            }
            else
            {
                // Yýðýný dengelemek için kontrol yap
                bool isBalanced = CheckBalance(cube);

                if (isBalanced)
                {
                    // Küpü yýðýna ekle
                    AddToStack(cube);
                }
                else
                {
                    // Yýðýndan çýkar ve oyunu bitir
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
                return true; // Küp dengeli
            }
        }

        return false; // Küp dengesiz
    }

    public void RemoveFromStack(GameObject cube)
    {
        cubeStack.Remove(cube);
        Destroy(cube);

        currentStackHeight -= stackHeight + stackOffset;
    }
}
