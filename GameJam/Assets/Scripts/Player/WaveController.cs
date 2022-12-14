using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private float durationTime = 1f;
    [SerializeField] private float travelSpeed = 2f;
    [SerializeField] private float travelDistance = 1f;
    [SerializeField] private Vector3 scaling = new Vector3(1.5f, 1.5f, 1f);
    private float damage = 2f;

    private Vector3 target;
    private float duration;

    void Start()
    {
        duration = durationTime;
        damage *= PlayerController.waveStrength;
        transform.localScale *= PlayerController.waveStrength;
        target = transform.localPosition + travelDistance * new Vector3(
                    Mathf.Sin((360-transform.eulerAngles.z) * Mathf.Deg2Rad),
                    Mathf.Cos((360-transform.eulerAngles.z) * Mathf.Deg2Rad),
                    0);
    }

    void Update()
    {
        if (duration > 0)
        {
            duration -= Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(
                                    transform.localPosition,
                                    target,
                                    travelSpeed * Time.deltaTime);
            transform.localScale.Scale(scaling);
        }
        else
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("EnemyLayer"))
        {
            col.gameObject.GetComponent<Enemy>().TakeDamage((int)damage);
        }
    }
}
