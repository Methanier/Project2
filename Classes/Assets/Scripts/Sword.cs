using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharlesProjects.Interfaces.Inventory;
using CharlesProjects.Interfaces.Weapons;

public class Sword : MonoBehaviour, IInventoryable, IWeapon {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void add()
    {
        //Adds item to inventory
    }

    public void remove()
    {
        //Removes item from inventory
    }

    public void equip()
    {
        //Equips Item
    }

    public void attack()
    {
        //Attacks
    }
}
