using UnityEngine;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour
{
    public GameObject UI;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        if (!target.isUpggraded)
        {
            upgradeCost.text = target.towerBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Maxed";
            upgradeButton.interactable = false;
        }

        sellAmount.text = target.towerBlueprint.GetSellAmount().ToString();
        UI.SetActive(true);
    }
    public void HideUI()
    {
        UI.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTower();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
