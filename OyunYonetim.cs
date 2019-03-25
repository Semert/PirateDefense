using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunYonetim : MonoBehaviour {

    public static OyunYonetim ornek;
   
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;


    void Awake()
    {
        ornek = this;
        
    }
    // Buraya yeni silahlar ekleyebilirsin.
 

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

 

    public void SelectNode(Node node)
    {

        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }


    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }


}
