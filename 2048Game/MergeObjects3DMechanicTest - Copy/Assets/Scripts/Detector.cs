using UnityEngine;

public class Detector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        InstantiateCube.Instance.CubeDestroy(collision, gameObject);
    }

}
