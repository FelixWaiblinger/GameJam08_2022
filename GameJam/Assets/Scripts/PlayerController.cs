using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CircleCollider2D col;

    [SerializeField] private float movementSpeed = 3;

    private PlayerControls controls;
    private InputAction move;
    private InputAction attack;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        move = controls.Player.Move;
        move.Enable();

        attack = controls.Player.Fire;
        attack.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        attack.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vec = move.ReadValue<Vector2>() * Time.deltaTime * movementSpeed;
        gameObject.transform.position += new Vector3(vec.x, vec.y, 0);
    }
}
