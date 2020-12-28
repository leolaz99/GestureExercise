using UnityEngine;

public class Move : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.right * 5 * Time.deltaTime);
    }
}
