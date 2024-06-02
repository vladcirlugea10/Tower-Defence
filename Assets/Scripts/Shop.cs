using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint standardTower;
    public TowerBlueprint mageTower;
    public TowerBlueprint laserCrystal;
    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTower()
    {
        Debug.Log("Standard tower selected!");
        buildManager.SelectTowerToBuild(standardTower);
    }
    public void SelectMageTower()
    {
        Debug.Log("MageTower selected!");
        buildManager.SelectTowerToBuild(mageTower);
    }
    public void SelectLaserCrystal()
    {
        Debug.Log("Laser Crystal selected!");
        buildManager.SelectTowerToBuild(laserCrystal);
    }
}
