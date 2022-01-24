using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(2);
        }
        if (other.gameObject.tag == "Win")
        {
            SceneManager.LoadScene(3);
        }
    }   

}
