using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuttingTowersManager : MonoBehaviour
{
    // Start is called before the first frame update
    private TowerSquelete towerToPut;
    public static PuttingTowersManager instance;
    public GameObject puttingTowerEffect;
    private Ground selectedGround;
    public GroundUI groundUI;

    private void Awake()
    {
        instance = this;
    }
    

   public bool Canbuild{ get{ return towerToPut != null; } }
    public bool HasMopney { get { return PlayerManager.Gold >=  towerToPut.cost; } }
    public void SelectTower(TowerSquelete tower)
    {
        towerToPut = tower;
        DeselectNode();
    }

   
    public void SelectGround(Ground ground) // allow us to detect the selected ground
    {
        if (selectedGround == ground)
        {
            DeselectNode();
            return;
        }

        selectedGround = ground;
        towerToPut = null;

        groundUI.SetTarget(ground);
    }
    public void DeselectNode() // allow us to hide the UI when is not selected
    {
        selectedGround = null;
        groundUI.Hide();
    }
    public TowerSquelete GetTower()
    {
        return towerToPut;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
