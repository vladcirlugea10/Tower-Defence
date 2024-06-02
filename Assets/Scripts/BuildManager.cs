using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }

    public GameObject buildEffect;
    public GameObject sellEffect;
    
    public GameObject standardarcherPrefab;
    
    private TowerBlueprint towerToBuild;
    
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } }

    public void SelectNode(Node node)
    {
        if(selectedNode==node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        towerToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.HideUI();
    }
    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
        selectedNode = null;

        DeselectNode();
    }
    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }
 
}
