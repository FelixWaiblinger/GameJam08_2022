using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 3;
    [SerializeField] private Transform indicator;
    [SerializeField] private GameObject attackWave;
    [SerializeField] private float reloadTime = 0.2f;
    [SerializeField] private GameObject gameOver;

    private SpriteRenderer body;
    private PlayerControls controls;
    private InputAction move;
    private InputAction attack;
    private float attackTimer = 0f;
    private List<GameObject> upgrades = new List<GameObject>();
    public static float waveStrength = 1f;
    private bool invincible = false;
    private Color invincibleColor = new Color(131f, 231f, 245f);
    private Color defaultColor;

    public void SpeedUp(float factor) { movementSpeed *= factor; }
    public void WaveUp(float factor) { waveStrength *= factor; }
    public void Remove(GameObject obj) { upgrades.Remove(obj); }
    public void SetInvincible()
    {
        invincible = invincible ? false : true;
        body.color = invincible ? invincibleColor : defaultColor;
    }

    void Awake()
    {
        controls = new PlayerControls();
        body = gameObject.GetComponentInChildren<SpriteRenderer>();
        defaultColor = body.color;
        waveStrength = 1f;
        movementSpeed = 3;
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

        if (attackTimer > 0) attackTimer -= Time.deltaTime;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (attackTimer > 0) return;
        
        Instantiate(attackWave, indicator.position, indicator.rotation);
        FindObjectOfType<AudioManager>().Play("ShootSound");
        attackTimer = reloadTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Game over
        if (!invincible && col.gameObject.layer == LayerMask.NameToLayer("EnemyLayer"))
        {
            move.Disable();
            attack.Disable();
            gameObject.GetComponent<CircleCollider2D>().enabled = false;

            Time.timeScale = 0.5f;
            Instantiate(gameOver, Vector3.zero, Quaternion.identity);
        }
        // collect upgrade
        else if (col.gameObject.layer == LayerMask.NameToLayer("UpgradeLayer"))
        {
            // deactivate upgrade "on screen"
            col.collider.enabled = false;
            col.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;

            // keep track of upgrade
            upgrades.Add(col.gameObject);

            // setup upgrade
            Upgrade upgrade = col.gameObject.GetComponent<Upgrade>();
            upgrade.Setup(gameObject);
        }
    }
}
