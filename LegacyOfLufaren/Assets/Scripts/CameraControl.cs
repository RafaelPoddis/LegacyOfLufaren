using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
