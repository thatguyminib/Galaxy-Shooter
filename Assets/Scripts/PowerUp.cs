using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField]
    float m_speed = 3.0f;

    [SerializeField]
    int m_powerupID; //0 = triple shot 1 = speed boost 2 = shields

	void Start () {
		
	}
	
	void Update () {
        transform.Translate(Vector3.down * m_speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if(m_powerupID == 0) { player.TripleShotPowerupOn(); }
                if(m_powerupID == 1) { player.SpeedBoostPowerupOn(); }
                if(m_powerupID == 2) { }
            }
            Destroy(this.gameObject);
        }
    }
}
