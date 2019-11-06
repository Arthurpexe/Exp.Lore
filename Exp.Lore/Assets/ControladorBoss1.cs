using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorBoss1 : MonoBehaviour
{
	public float raioDeVisao = 10f;


	Transform target;
	NavMeshAgent agent;
	Boss1Combate combate;
	


	// Start is called before the first frame update
	void Start()
    {
		target = Ref_posiçao_jogador.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
		combate = GetComponent<Boss1Combate>();

	}

    // Update is called once per frame
    void Update()
    {
		
		
		float distancia = Vector3.Distance(target.position, transform.position);


		if (distancia <= raioDeVisao)
		{

			PersonagemStats alvoStats = target.GetComponent<PersonagemStats>();
			if (alvoStats != null)
			{
				combate.Ataque(alvoStats);
			}
			
			

				OlharParaAlvo();
			
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
			


