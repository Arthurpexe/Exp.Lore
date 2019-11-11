using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorInimigo : MonoBehaviour
{
	public float raioDeVisao = 10f;

	Renderer rend;
	Transform target;
	NavMeshAgent agent;
	PersonagemCombate combate;
	public GameObject[] Waypoints;
	private int WaypointDestino = 0;

	// Start is called before the first frame update
	void Start()
    {
		target = Ref_posiçao_jogador.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
		combate = GetComponent<PersonagemCombate>();
		rend = GetComponentInChildren<Renderer>();

	}

    // Update is called once per frame
    void Update()
    {
		rend.material.color = Color.white;
		float distancia = Vector3.Distance(target.position, transform.position);

		agent.SetDestination(Waypoints[WaypointDestino].transform.position);

		float distancia_inimigo_destino = Vector3.Distance(Waypoints[WaypointDestino].transform.position, agent.transform.position);

		if (distancia_inimigo_destino < 2)
		{
			if (WaypointDestino < Waypoints.Length - 1)
			{
				WaypointDestino++;
			}
			else
			{
				WaypointDestino = 0;
			}

		}



		if (distancia <= raioDeVisao)
		{
			
			agent.SetDestination(target.position);

			if(distancia <= 3)
			{
				JogadorStats alvoStats = target.GetComponent<JogadorStats>();
				if(alvoStats != null)
				{
					combate.Ataque(alvoStats);
				}
				
				OlharParaAlvo();
			}
		}
    }

	void OlharParaAlvo()
	{
		Vector3 direcao = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direcao.x, 0, direcao.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, raioDeVisao);
	}
}


