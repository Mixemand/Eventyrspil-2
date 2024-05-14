using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] private GameObject tower;

    sceneManager sm;

    void Start()
    {
        sm = GameObject.Find("SceneManager").GetComponent<sceneManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider == null) return;

            if (hit.collider.CompareTag("Grid"))
            {
                Transform tileT = hit.collider.transform;
                if (tileT.GetComponent<tile>().IsPlaced) return;

                Instantiate(tower, tileT.position, Quaternion.identity);
                tileT.GetComponent<tile>().IsPlaced = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sm.MainMenu();
        }
    }
}
