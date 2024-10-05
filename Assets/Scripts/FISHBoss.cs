using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class FISHBoss : MonoBehaviour
{
    public GameObject player;
    public GameObject jumpscare;
    public int HP = 50;
    public RectTransform staminometer;
    public GameObject explosion;
    public AudioSource bossAudio;
    public AudioSource trueEndAudio;

    private bool isExploding = false;
    private Vector3 lastPlayerPosition = Vector3.zero;
    private NavMeshAgent agent;
    private bool isPaused = false;
    private bool isTrueEnd = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isPaused) return;
        if (player.transform.position != lastPlayerPosition && (!isExploding || isTrueEnd)) agent.SetDestination(player.transform.position);
        if (isExploding && !isTrueEnd) agent.isStopped = true;
        else agent.isStopped = false;
        lastPlayerPosition = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player || other.transform.IsChildOf(player.transform))
        {
            StartCoroutine(Jumpscare());
        } else if(other.tag == "Bullet")
        {
            HP--;

            if(isTrueEnd)
            {
                agent.speed *= 1.01f;
                bossAudio.pitch *= 1.0025f;
                player.GetComponent<PlayerController>().playerSpeed *= 1.00852f;
            } else
            {
                agent.speed *= 1.1f;
                bossAudio.pitch *= 1.025f;
                player.GetComponent<PlayerController>().playerSpeed *= 1.0852f;
            }

            staminometer.sizeDelta = new((565.96f / 20) * HP, staminometer.sizeDelta.y);

            StartCoroutine(Explosion());

            if (HP == 0)
            {
                GameManager.Instance.DoWin();
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator Explosion()
    {
        isExploding = true;
        GameObject _explosion = Instantiate(explosion, explosion.transform.position, explosion.transform.rotation, transform);
        _explosion.SetActive(true);
        _explosion.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.4f);
        isExploding = false;
        Destroy(_explosion);
    }

    private IEnumerator Jumpscare()
    {
        jumpscare.SetActive(true);
        yield return new WaitForSeconds(.5f);
        if(MainMenuManager.checkpointMode)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else
            SceneManager.LoadScene(0);
    }

    public void startTrueEnd()
    {
        StartCoroutine(doTrueEnd());
    }

    public IEnumerator doTrueEnd()
    {
        bossAudio.Pause();
        player.GetComponent<PlayerController>().enabled = false;
        agent.enabled = false;
        isPaused = true;
        trueEndAudio.Play();
        yield return new WaitForSeconds(7f);
        HP = 200;
        isTrueEnd = true;
        yield return new WaitForSeconds(7f);
        isPaused = false;
        agent.enabled = true;
        player.GetComponent<PlayerController>().enabled = true;
        bossAudio.Play();
    }
}
