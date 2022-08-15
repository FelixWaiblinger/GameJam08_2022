using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 3;
    [SerializeField] private Transform indicator;
    [SerializeField] private GameObject attackWave;
    [SerializeField] private GameObject gameOver;

    private PlayerControls controls;
    private InputAction move;
    private InputAction attack;
    private List<GameObject> upgrades = new List<GameObject>();
    private bool invincible;

    public void SetInvincible() { invincible = invincible ? false : true; }
    public void SpeedUp(float factor) { movementSpeed *= factor; }
    public void Remove(GameObject obj) { upgrades.Remove(obj); }
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
        GameObject wave = Instantiate(attackWave, indicator.position, indicator.rotation);

        wave.transform.localScale.Scale(new Vector3(3, 3, 1));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("EnemyLayer"))
        {
            // Game over
            move.Disable();
            attack.Disable();
            gameObject.GetComponent<CircleCollider2D>().enabled = false;

            Time.timeScale = 0.5f;
            Instantiate(gameOver, Vector3.zero, Quaternion.identity);
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("UpgradeLayer"))
        {
            // deactivate upgrade "on screen"
            col.collider.enabled = false;
            col.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;

            // keep track of upgrade
            upgrades.Add(col.gameObject);

            // setup upgrade
            Upgrade upgrade = col.gameObject.GetComponent<Upgrade>();
            upgrade.Setup(gameObject, attackWave);
        }
    }
}
