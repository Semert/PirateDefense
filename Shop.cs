using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    OyunYonetim oyunYonetim;


    public TurretBlueprint standardTurret;
   public TurretBlueprint missileLauncher;
    public TurretBlueprint iceTurret;
    // public TurretBlueprint laserBeamer;


    void Start()
    {
        oyunYonetim = OyunYonetim.ornek;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        oyunYonetim.SelectTurretToBuild(standardTurret);
        
    }
    public void SelectAnotherTurret()
    {
        Debug.Log("Another Turret Selected");
        oyunYonetim.SelectTurretToBuild(missileLauncher);
    }

    public void SelectIceTurret()
    {
        Debug.Log("Ice Turret Selected");
        oyunYonetim.SelectTurretToBuild(iceTurret);
    }

    /*  public void SelectLaserBeamer()
      {
          Debug.Log("Laser Beamer Selected");
          buildManager.SelectTurretToBuild(laserBeamer);
      }*/


}
