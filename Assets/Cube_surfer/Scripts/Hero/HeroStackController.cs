<<<<<<< HEAD
//
=======
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStackController : MonoBehaviour
{
<<<<<<< HEAD
    public List<GameObject> blockList = new List<GameObject>();
    private GameObject lastBlockObject;
    //private Vector3 transformUp;
    public GameObject _trail;
    //private Vector3 constTransform = new Vector3(0, 0.3f, 0);
=======
    
    public List<GameObject> blockList = new List<GameObject>();
    private GameObject lastBlockObject;
    public GameObject _trail;
    private Vector3 constTransform = new Vector3(0,2.3f,0);
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53

    public GameObject getCubeprefab;

    private void Start()
    {
        UpdateLastBlockObject();
    }
<<<<<<< HEAD

=======
   
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
    public void IncreaseNewBlock(GameObject _gameObject)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        _gameObject.transform.position = new Vector3(transform.position.x, lastBlockObject.transform.position.y - 2f, transform.position.z);
        _gameObject.transform.SetParent(transform);
        blockList.Add(_gameObject);
        UpdateLastBlockObject();
        StartCoroutine(CreateAndDestroyPrefab());
    }


    public void DecreaseBlock(GameObject _gameObject)
    {
        _gameObject.transform.parent = null;
        blockList.Remove(_gameObject);
        UpdateLastBlockObject();
<<<<<<< HEAD
        Destroy(_gameObject, 2f);
=======
        Destroy(_gameObject , 2f);
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
    }

    public void UpdateLastBlockObject()
    {
        lastBlockObject = blockList[blockList.Count - 1];
<<<<<<< HEAD
        CheckBalance();
=======
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
        //transformUp = lastBlockObject.transform.position;
    }
    private void Update()
    {
<<<<<<< HEAD
        _trail.transform.position = lastBlockObject.transform.position;
=======
        constTransform.x = lastBlockObject.transform.position.x;
        constTransform.z = lastBlockObject.transform.position.z;
        _trail.transform.position = constTransform;
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
    }

    IEnumerator CreateAndDestroyPrefab()
    {
        GameObject newPrefab = Instantiate(getCubeprefab, this.transform);
<<<<<<< HEAD
        newPrefab.transform.SetParent(this.transform); //Prefab'ýn parent'ýný belirler
        yield return new WaitForSeconds(2f);
        Destroy(newPrefab);
    }

    void CheckBalance()
    {
        if (blockList.Count > 1)
        {
            if (lastBlockObject.transform.position.y - blockList[blockList.Count - 2].transform.position.y != 2)
            {
                Vector3 temp = blockList[blockList.Count - 2].transform.position;
                temp.y -= 2;
                lastBlockObject.transform.position = temp;
            }
        }
        for(int i=1;i<blockList.Count;i++)
        {
            Vector3 temp = blockList[i-1].transform.position;
            temp.y -= 2;
            blockList[i].transform.position = temp;
        }
    }
}
=======
        //newPrefab.transform.SetParent(this.transform); //Prefab'ýn parent'ýný belirler
        yield return new WaitForSeconds(2f);
        Destroy(newPrefab);
    }
}
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
