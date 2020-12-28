using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    bool touchStart = false;
    public GameObject prefab;
    Vector3 pointA;
    Vector3 pointB;

    void moveCharacter(Vector3 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.touches[i].position.x < Screen.width / 2)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
                    }

                    if (Input.GetMouseButton(0))
                    {
                        touchStart = true;
                        pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
                    }

                    else
                    {
                        touchStart = false;
                    }
                }

                if (Input.touches[i].position.x > Screen.width / 2)
                {
                    Instantiate(prefab, player.position, player.rotation);
                }
            }          
        }
    }
    
    void FixedUpdate()
    {
        if (touchStart)
        {
            Vector3 offset = pointB - pointA;
            Vector3 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * -1);
        }
    } 
}