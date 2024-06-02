using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionoffset;

    public GameObject tower;
    public TowerBlueprint towerBlueprint;
    public bool isUpggraded=false;

    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionoffset;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if(tower != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        
        if (!buildManager.CanBuild)
            return;

        BuildTower(buildManager.GetTowerToBuild());
    }
    void BuildTower(TowerBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not Enough money");
            return;
        }
        PlayerStats.Money -= blueprint.cost;

        GameObject _tower = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        towerBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Tower built!");
    }
    public void UpgradeTower()
    {
        if (PlayerStats.Money < towerBlueprint.upgradeCost)
        {
            Debug.Log("Not Enough money");
            return;
        }
        PlayerStats.Money -= towerBlueprint.upgradeCost;

        Destroy(tower);

        GameObject _tower = (GameObject)Instantiate(towerBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpggraded = true;

        Debug.Log("Tower upgraded!");
    }
    public void SellTurret()
    {
        PlayerStats.Money += towerBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(tower);
        towerBlueprint = null;
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }


}
