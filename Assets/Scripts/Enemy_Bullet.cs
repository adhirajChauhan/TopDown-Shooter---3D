using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Transform _player;
    private Vector3 _target;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _target = new Vector3(_player.position.x, _player.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);

        if (transform.position.x == _target.x && transform.position.z == _target.z)
        {
            DestroyEnemyBullet();
        }
    }

    void DestroyEnemyBullet()
    {
        Destroy(gameObject);
        //Also destroy after travelling some distance
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyEnemyBullet();
        }
    }
}
