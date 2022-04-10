using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundUI : MonoBehaviour
{
    private Ground target;
	public GameObject showingUI;
	public Text upgradeCost;
	public Text sellAmount;
	public Button upgradeButton;


	public void Hide()
	{
		showingUI.SetActive(false);
	}
	void Start()
	{

	}
	public void Upgrade()
	{
		target.Upgrade();
		PuttingTowersManager.instance.DeselectNode();
	}
	public void Sell()
	{
		target.SellTurret();
		PuttingTowersManager.instance.DeselectNode();
	}
	public void SetTarget(Ground _target)
	{
		target = _target;

		transform.position = target.GetBuildPosition();


		if (!target.isUpgraded)
		{
			upgradeCost.text = "$" + target.towersquelete.upgradecost;
			upgradeButton.interactable = true;
		}
		else
		{
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
		}

		sellAmount.text = "$" + target.towersquelete.QuantityForSelling();

		showingUI.SetActive(true);
	}
	// Start is called before the first frame update
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
