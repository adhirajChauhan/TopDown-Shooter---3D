using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform _bulletSpawnPoint;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        PlayerRotation();
        BulletSpawning();
    }

    void Movement()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        Vector3 _movement = new Vector3(_horizontal, 0, _vertical);
        transform.Translate(_movement * _movementSpeed * Time.deltaTime, Space.World);
    }

    void PlayerRotation()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
        }
    }

    void BulletSpawning()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(bulletPrefab, _bulletSpawnPoint.transform.position, transform.rotation);
        }
    }
}
