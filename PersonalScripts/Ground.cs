using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ground : MonoBehaviour
{
    public Material newMaterial;
    public Material anothernewMaterial;
    private Renderer rend;
    private Material ancientMaterial;
    [Header("Optional")]
    public GameObject tower;
    public GameObject nomoneyeffect;
    PuttingTowersManager puttingTower;
    public Vector3 possitionOffSet;
    public bool isUpgraded = false;
    public TowerSquelete towersquelete;
   
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        ancientMaterial = rend.material;
        puttingTower = PuttingTowersManager.instance;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        { return; }
       

        if(tower != null)
        {
            puttingTower.SelectGround(this);
            return;
        }
        if (!puttingTower.Canbuild)
        {
            return;
        }
        Debug.Log("The turret is put");

       BuildTowerOn(puttingTower.GetTower());
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + possitionOffSet;
    }

    public void BuildTowerOn(TowerSquelete squelete)// function that allow us to put the tower on the selected ground
    {
        if (PlayerManager.Gold < squelete.cost)
        {
            return;
        }
        PlayerManager.Gold -= squelete.cost;

        GameObject _tower = Instantiate(squelete.prefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;
        towersquelete = squelete;

        GameObject particle = (GameObject)Instantiate(puttingTower.puttingTowerEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(particle, 5f);
    }
    public void Upgrade()  // I figured out it would be like the building tower, so i used the code again but this time with the other prefab and the upgrade cost;
    {
        if (PlayerManager.Gold < towersquelete.upgradecost)
        {
            return;
        }
        PlayerManager.Gold -= towersquelete.upgradecost;
        Destroy(tower);
        GameObject _tower = Instantiate(towersquelete.upgradeprefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;
        GameObject particle = (GameObject)Instantiate(puttingTower.puttingTowerEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(particle, 5f);
        isUpgraded = true;
    }
    public void SellTurret()
    {
        PlayerManager.Gold += (towersquelete.cost/2);

        Destroy(tower);
        towersquelete = null;
    }



    void OnMouseEnter()  // the hover effect when you move the mouse on a groud
    {
        if(EventSystem.current.IsPointerOverGameObject())
        { return; }
        if (!puttingTower.Canbuild)
        {
            return;
        }
        if (puttingTower.HasMopney)
        {
            rend.material = newMaterial;
        }
        else
        {
            rend.material = anothernewMaterial;
        }
        
    }
    void OnMouseExit() // when you move the mouse of the ground it restart the material 
    {
        rend.material = ancientMaterial;
    }
}
