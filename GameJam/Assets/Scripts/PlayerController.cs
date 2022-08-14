using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 3;
    [SerializeField] private Transform indicator;
    [SerializeField] private GameObject attackWave;

    private PlayerControls controls;
    private InputAction move;
    private InputAction attack;

    void Awake()
    {
        controls = new PlayerControls();
    }

    void OnEnable()
    {
        move = controls.Player.Move;
        move.Enable();

        attack = controls.Player.Fire;
        attack.Enable();
        attack.performed += Attack;
    }

    void OnDisable()
    {
        move.Disable();
        
        attack.performed -= Attack;
        attack.Disable();
    }

    void Update()
    {
        Vector2 vec = move.ReadValue<Vector2>() * Time.deltaTime * movementSpeed;
        transform.position += new Vector3(vec.x, vec.y, 0);
    }

    public void Attack(InputAction.CallbackContext context)
    {
        Instantiate(attackWave, indicator.position, indicator.rotation);
    }
}
