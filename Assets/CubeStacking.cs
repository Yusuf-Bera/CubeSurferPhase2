using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeStacking : MonoBehaviour
{
    public Action<GameObject> cubeAttach;
    public Action<GameObject> cubeDetach;

    //public GameObject humanModel;

    public void Start()
    {
        cubeAttach += Attachment;
        cubeDetach += Detachment;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cube")
        {
            collision.gameObject.tag = "Untagged";
            cubeAttach(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            cubeDetach(collision.gameObject);
        }
        else if (collision.gameObject.tag == "finish")
        {
        }
    }

    public void Attachment(GameObject other)
    {
        transform.position = new Vector3(transform.position.x, GetComponent<Collider>().bounds.size.y * (transform.parent.childCount - 1) + 2f, transform.position.z);

        other.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        other.transform.position = new Vector3(transform.position.x, GetComponent<Collider>().bounds.size.y * (transform.parent.childCount - 2) + 2f, transform.position.z);
        other.AddComponent<CubeStacking>();
        other.transform.parent = transform.parent;
    }

    public void Detachment(GameObject other)
    {
        foreach (Transform child in other.transform.parent)
        {
            child.tag = "Untagged";
        }

        Destroy(GetComponent<CubeStacking>());
        transform.parent = null;

    }

    public void OnDestroy()
    {
        cubeAttach -= Attachment;
        cubeDetach -= Detachment;
    }
}
