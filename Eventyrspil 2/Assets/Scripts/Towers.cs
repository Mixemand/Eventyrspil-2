using System.Collections;
using UnityEngine;
    
public class Towers : MonoBehaviour
{
    [SerializeField] float dist;
    [SerializeField] float maxTime;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] GameObject bullet;
    bool canShoot = true;
    float time;

    void Update()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(1, 0), dist, enemyLayer);
        if (canShoot &&  hit.collider != null)
        {
            canShoot = false;
           

            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        Instantiate(bullet, new Vector2(transform.position.x + 0.5f, transform.position.y), Quaternion.identity);

        yield return new WaitForSeconds(time);

        canShoot = true;
        time = maxTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + dist, transform.position.y));
    }
}
