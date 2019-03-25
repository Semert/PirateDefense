using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy1))]
public class EnemyMovement : MonoBehaviour {

    private Enemy1 enemy;

    
    private Transform target; // Hedef bulmamız lazım, bu yüzden yaptık
    private int waveIndex = 0; // Takip ettiğimiz o an ki indeks

    // Current waypointindex we are pursuing

    void Start()
    {
        enemy = GetComponent<Enemy1>();

        // STATIC olduğu için bunu yapabiliyoruz.   
        target = WayPoints.points[0]; // İlk hedefimiz points[0] elemanı olucak
    }

    void Update()
    {   //  The way you get direction vector one point to another vector, you simply substract them
        // So in our case we want to point from our current position to towards the target position.
        Vector3 dir = target.position - transform.position;

        Vector3 yon = WayPoints.points[waveIndex].position - transform.position;
        float angle = Mathf.Atan2(yon.x, -yon.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        // We implement to switch waypoints ( Waypointsleri sırayla değiştirme)                           
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
        // RANGE'DEN CIKTIKTAN SONRA HIZI ESKİ HALİNE GETİRME
        enemy.speed = enemy.startSpeed;
    }

    void GetNextWayPoint()
    {   // Array'ın boyuna gelirse bu objeyi destory et.
        if (waveIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        // Bir arttırıp diğerine geçiş
        waveIndex++;
        target = WayPoints.points[waveIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
