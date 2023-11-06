using System.Collections;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPosition;    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        startPosition = transform.position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.constraints = RigidbodyConstraints.None;
            startPosition = Input.mousePosition;
            StartCoroutine(nameof(CallChangeParent));
        }
        else if (Input.GetMouseButtonUp(0))
        {
            rb.constraints = RigidbodyConstraints.None;
            Vector3 releasePosition = Input.mousePosition;
            Vector3 direction = (startPosition - releasePosition).normalized;
            rb.velocity = -direction * 10f;
            StartCoroutine(nameof(CallChangeParent));
        }
    }


    IEnumerator CallChangeParent()
    {
        yield return new WaitForSeconds(0.35f);
        transform.parent = InstantiateCube.Instance.ParentofCubes.transform;
    }
}
