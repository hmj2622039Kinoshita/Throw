using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent <CharacterController>();
    }

    private void Update()
    { // ƒvƒŒƒCƒ„‚ÌˆÚ“®
        Vector3 move = new Vector3(0, 0, 0);
        if(Input.GetKey(KeyCode.W))
        {
            move += transform.forward;
        }
        if(Input.GetKey(KeyCode.S))
        {
            move -= transform.forward;
        }
        if(Input.GetKey(KeyCode.A))
        {
            move -= transform.right;
        }
        if(Input.GetKey(KeyCode.D))
        {
            move+= transform.right;
        }

        controller.Move(move * speed * Time.deltaTime);
    }

}
