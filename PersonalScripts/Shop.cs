using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    PuttingTowersManager puttingTower;
    public TowerSquelete standartTower;
    public TowerSquelete missileTower;
    public TowerSquelete laserTower;

    public void SelectFirstTurret()
    {
        Debug.Log("Turret Purchased");
        puttingTower.SelectTower(standartTower);
    }
    public void SelectSecondTurret()
    {
        Debug.Log("Turret Purchased");
        puttingTower.SelectTower(missileTower);
    }
    public void SelectThirdTurret()
    {
        Debug.Log("Turret Purchased");
        puttingTower.SelectTower(laserTower);
    }

    // Start is called before the first frame update
    void Start()
    {
        puttingTower = PuttingTowersManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
