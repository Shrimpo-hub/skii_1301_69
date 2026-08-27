using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float forcePower = 10f;

    [SerializeField]
    private Rigidbody rb;

    private InputAction moveAction;
    private Vector2 moveValue;

    [SerializeField]
    private int point;
    public int Point { get { return point; } set { point = value; } }

    [SerializeField]
    private int hp;
    public int HP { get { return hp; } set { hp = value; } }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.Enable();

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MoveLeftOrRight();
    }

    private void MoveLeftOrRight()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        rb.AddForce(moveValue.x * Vector3.right * forcePower);
    }
}
