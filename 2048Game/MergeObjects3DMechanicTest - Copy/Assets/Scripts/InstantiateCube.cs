using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InstantiateCube : MonoBehaviour
{
    [SerializeField] public GameObject ParentofCubes;
    [SerializeField] private List<GameObject> Cubes;
    [SerializeField] private Transform InstantiateTransform;

    private GameObject prevCube;
    private Transform ChangeCubeTransform;
    private int count;

    private static InstantiateCube _instance;

    public static InstantiateCube Instance => _instance ?? (_instance = FindObjectOfType<InstantiateCube>());


    private void Start()
    {
        Instantiate();
    }

    private void Update()
    {
        if (transform.childCount == 0)
        {
            Instantiate();
        }
    }

    public void Instantiate()
    {
        if (prevCube != null)
        {
            Destroy(prevCube.GetComponent<CubeController>());
        }

        GameObject Instantiatecube = Instantiate(Cubes[Random.Range(0, Cubes.Count)], InstantiateTransform.position, InstantiateTransform.rotation);

        Instantiatecube.transform.parent = transform;
        Destroy(Instantiatecube.GetComponent<CubeController>());
        Destroy(Instantiatecube.GetComponent<BoxCollider>());
        prevCube = Instantiatecube;
        Instantiatecube.AddComponent<Rigidbody>();
        Instantiatecube.AddComponent<BoxCollider>();
        Instantiatecube.AddComponent<CubeController>();
        Instantiatecube.AddComponent<Detector>();
    }

    public void CubeDestroy(Collision collision, GameObject destroyedCube)
    {
        if (collision.gameObject.CompareTag(destroyedCube.tag))
        {
            bool result = Int32.TryParse(collision.gameObject.tag, out int tagInt);

            count++;
            if (count == 2)
            {
                ChangeCubeTransform = destroyedCube.transform;
                Destroy(collision.gameObject);
                Destroy(destroyedCube);

                if (tagInt != Cubes.Count)
                {
                    GameObject Instantiatecube = Instantiate(Cubes[tagInt], ChangeCubeTransform.position, ChangeCubeTransform.rotation);

                    Instantiatecube.AddComponent<Rigidbody>();
                    Instantiatecube.AddComponent<BoxCollider>();
                    Instantiatecube.AddComponent<Detector>();
                }
                count = 0;

                UIManager.Instance.ShowScore();
            }
        }

    }
}
