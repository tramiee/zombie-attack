using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public LayerMask layer;
    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        laser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        LookatMouse();

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(shootLaser());
        }

    }

    IEnumerator shootLaser()
    {
        laser.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        laser.SetActive(false);
    }
    public void LookatMouse()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;

        if(playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie")
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
