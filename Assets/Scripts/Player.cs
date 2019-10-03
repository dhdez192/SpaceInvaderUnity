using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public or private reference
    // data type (int, float, bool, string)
    // every variable has a name
    // optional value assigned

     // Typically want to keep all variables as a private reference
     // To make private variable visible in inspector, create an attribute
    [SerializeField] private float _speed= 6f;
    [SerializeField] private GameObject _laserPrefab;
    private Vector3 _laserOffset = new Vector3(0, 0.8f, 0);
    [SerializeField] private float _fireRate = 0.5f;
    private float _canFire = 0.1f;
    [SerializeField] private int _lives = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        // take the current position = new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // new Vector3(1, 0, 0)
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        
        // Clamping the top and bottom bounds
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        // Horizontal Teleport out of bounds
        if (transform.position.x > 12f)
        {
            transform.position = new Vector3(-12f, transform.position.y, 0);
        }
        else if (transform.position.x < -12f)
        {
            transform.position = new Vector3(12f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
     _canFire = Time.time + _fireRate;
     Instantiate(_laserPrefab, transform.position + _laserOffset, Quaternion.identity); 
    }

    public void Damage()
    {
        _lives --;

        if(_lives < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
