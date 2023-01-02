using UnityEngine;
public class Gift : MonoBehaviour
{
    [SerializeField] float RotateSpeed = 90;
    void Update()
    {
        transform.Rotate(0,  RotateSpeed * Time.deltaTime * 2f,0);
    }
}
