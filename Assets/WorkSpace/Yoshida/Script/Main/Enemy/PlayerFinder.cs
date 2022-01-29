using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
	public float m_fSightAngle = 45.0f;
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			Vector3 posDelta = other.transform.position - transform.position;
			float targetAngle = Vector3.Angle(transform.forward, posDelta);
			if (targetAngle < m_fSightAngle)
			{
				if (Physics.Raycast(transform.position, new Vector3(posDelta.x, 0f, posDelta.z), out RaycastHit hit))
				{
					if (hit.collider == other)
					{
						Debug.Log("視界の範囲内＆視界の角度内＆障害物なし");
						GetComponentInParent<EnemyAction>().Throwing(true);
                    }
					else
                    {
						GetComponentInParent<EnemyAction>().Throwing(false);
					}
				}
			}
		}
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
			GetComponentInParent<EnemyAction>().Throwing(false);
		}
    }
}
