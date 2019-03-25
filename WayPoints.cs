using UnityEngine;

public class WayPoints : MonoBehaviour
{

    public static Transform[] points; // Her yerden ulaşılabilmesi için "static yaptık
                                      // Bu sayede referans gerekmeksizin ulaşılabilir oldu.

    void Awake()
    {
        points = new Transform[transform.childCount];  // Points array'imize waypoints'in child sayısı kadar
        for (int i = 0; i < points.Length; i++)        // boyut verdik.    
        {
            points[i] = transform.GetChild(i);  // Bütün child'ları points array'imizin içine sırayla atadık.
        }
    }
    // STATİC WE CAN EAİSLY ACCESS!!! (ERİŞMEK)..
}