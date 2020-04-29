using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _stoppingDistance;
    [SerializeField]
    private float _retreatDistance;
    public Transform player;

    private float _timeBtwShots;
    public float _startTimeBtwShots;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        _timeBtwShots = _startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > _stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.position) < _stoppingDistance && Vector3.Distance(transform.position, player.position) > _retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, player.position) < _retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -_speed * Time.deltaTime);
        }

        if (_timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            _timeBtwShots = _startTimeBtwShots;
        }
        else
        {
            _timeBtwShots -= Time.deltaTime;
        }
    }
}
