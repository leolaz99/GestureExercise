using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    bool isMoving;
    public GameObject prefab;
    public Vector2 startPos;
    public Vector2 direction;

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
                    switch (Input.touches[i].phase)
                    {
                        case TouchPhase.Began:
                            startPos = Input.touches[i].position;
                            break;

                        case TouchPhase.Moved:
                            direction = Input.touches[i].position - startPos;
                            isMoving = true;
                            break;

                        case TouchPhase.Ended:
                            isMoving = false;
                            break;
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
        if (isMoving)
        {
            Vector3 clamping = Vector2.ClampMagnitude(direction, 1.0f);
            moveCharacter(clamping);
        }
    } 
}