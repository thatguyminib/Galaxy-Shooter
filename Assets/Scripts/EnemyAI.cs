using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    float m_speed;

	void Start () {
		
	}
	
	void Update () {
        //move enemy down
        transform.Translate(Vector3.down * m_speed * Time.deltaTime);

        //when off the screen respawn back at the top in a random x position
        if(transform.position.y < -6.17f)
        {
            float randomXPos = Random.Range(-8f,8f);
            transform.position = new Vector3(randomXPos, 6.17f, 0f);
        }
	}
}
