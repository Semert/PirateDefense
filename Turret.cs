using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;
    private Enemy1 targetEnemy;
    [Header("Özellikler")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    /*  [Header("Yavaslatma")]

      // YAVAŞLATMA VE DAMAGE

      public int damageOverTime = 30;  
      public float slowAmount = 2f;

      public bool useLaser = false;  VE PUBLİC BOOL' YAPIP SONRA BURADA BOOL = FALSE YAPICAZ, SADECE İSTEDİĞİMİZ TURRETİ INSPECTORDAN AÇICAZ */
    /* public LineRenderer lineRenderer;
     public ParticleSystem impactEffect;
     public Light impactLight;*/
    ////////////////////////////////////////


    /* [Header("Sprite")]
     [SerializeField]
     private Sprite sprite;


     public Sprite Sprite
     {
         get
         {
             return sprite;
         }
     }*/

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float ShortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < ShortestDistance)
            {
                ShortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && ShortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy1>();
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
            return;


        LockOnTarget();
   
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
      //  Laser(); VE PUBLİC BOOL' YAPIP SONRA BURADA BOOL = FALSE YAPICAZ, SADECE İSTEDİĞİMİZ TURRETİ INSPECTORDAN AÇICAZ
        fireCountdown -= Time.deltaTime;
    }

    void LockOnTarget()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }


  /*  void Laser()
    {

   //     DAMAGE VE YAVAŞLATMA!!!!!!

     //   targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);


   /*    GRAPHİC!!!!

    if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
        
    }  
    */
    
    void Shoot()
    {
        GameObject BulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = BulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
