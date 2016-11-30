using UnityEngine;
using System.Collections;

public class WeaponGUI : MonoBehaviour 
{
    public WeaponSystem playerWeaponSystem;
    float screenScale = Screen.width / 1920.0f;

	void Start () 
    {
	
	}

    void OnGUI()
    {
        for (int i = 0; i < playerWeaponSystem.weapons.Length; i++)
        {
            GUI.Label(
                new Rect(
                    new Vector2(i * 200.0f * screenScale, 0.0f),
                    new Vector2(200.0f * screenScale, 100.0f * screenScale)),
                playerWeaponSystem.weapons[i].objName);
                
        }
    }

    void OnDestroy()
    {
        
    }
}
