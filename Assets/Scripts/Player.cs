using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool m_canTripleShot;
    public bool m_hasSpeedBoost;


    [SerializeField]
    GameObject m_laserPrefab;

    [SerializeField]
    GameObject m_tripleShotPrefab;

    [SerializeField]
    float m_speed = 5f;

    [SerializeField]
    float m_initialSpeed = 5f;

    [SerializeField]
    float m_boostSpeed = 10f;

    [SerializeField]
    float m_fireRate = 0.25f;

    float m_canFire = 0.0f;


	void Start () {
        transform.position = new Vector3(0, 0, 0);
	}
	
	void Update ()
    {
        Movement();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (Time.time > m_canFire)
            {
                if (m_canTripleShot)
                {
                    Instantiate(m_tripleShotPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(m_laserPrefab, new Vector3(transform.position.x, transform.position.y + .47f, 0f), Quaternion.identity);
                }
                m_canFire = Time.time + m_fireRate;
            }
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (m_hasSpeedBoost) { m_speed = m_boostSpeed; } else { m_speed = m_initialSpeed; }

        transform.Translate(Vector3.right * m_speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * m_speed * verticalInput * Time.deltaTime);

        if (transform.position.y > 0f)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 9.4f)
        {
            transform.position = new Vector3(-9f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.4f)
        {
            transform.position = new Vector3(9f, transform.position.y, 0);
        }
    }

    public void TripleShotPowerupOn()
    {
        m_canTripleShot = true;
        StartCoroutine(TripleShotCooldown());
    }

    public void SpeedBoostPowerupOn()
    {
        m_hasSpeedBoost = true;
        StartCoroutine(SpeedBoostCooldown());
    }

    public IEnumerator TripleShotCooldown()
    {
        yield return new WaitForSeconds(5.0F);
        m_canTripleShot = false;
    }

    public IEnumerator SpeedBoostCooldown()
    {
        yield return new WaitForSeconds(5.0f);
        m_hasSpeedBoost = false;
    }
}
