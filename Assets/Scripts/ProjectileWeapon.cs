using UnityEngine;
using System.Collections;

public class ProjectileWeapon : MonoBehaviour 
{
    public GameObject shell;
    private Vector3 spawnPos;
    public ProjectileStats stats;

	void Start () 
    {
        shell = (GameObject)Resources.Load("Shell", typeof(GameObject));
        if (shell == null)
            Debug.Log("Shell object is not properly assigned!");
        stats = ScriptableObject.CreateInstance<ProjectileStats>();
        stats.Init();
	}

    /// <summary>
    /// Set spawn position of shell.
    /// </summary>
    /// <param name="indicator">position</param>
    public void Init(Vector3 indicator)
    {
        spawnPos = indicator;
    }
	
    public void Shoot()
    {
        GameObject spawnedShell;
        spawnedShell = Instantiate(shell);
        spawnedShell.transform.position = spawnPos;
        spawnedShell.transform.rotation = transform.rotation;
        spawnedShell.GetComponent<Shell>().Init(stats.shellSpeed, stats.RollDmg());
    }
}
