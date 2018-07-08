using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    [SerializeField]
    float m_speed = 10.0f;

	void Start () {
		
	}
	
	void Update () {
        transform.Translate(Vector3.up * m_speed * Time.deltaTime);

        if(transform.position.y >= 5.35f)
        {
            Destroy(gameObject);
        }
	}
}
