using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharlesProjects.Interfaces.Inventory;
using CharlesProjects.Interfaces.Spells;
using CharlesProjects.Interfaces.Weapons;

public class Test : MonoBehaviour {


    public List<IInventoryable> inventory;
    public List<ISpell> spells;
    public List<IWeapon> weapons;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IInventoryable CheckItem()
    {
        
        foreach(IInventoryable item in inventory)
        {
            if (item == typeof(Sword))
            {
                return item;
            }
        }
        return null;
    }
}
