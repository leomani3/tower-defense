using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBladeTurret : BaseTurret
{
    public override void Attack()
    {

        cooldown = reloadTime;
        List<int> targetsToRemove = new List<int>();
        for (int i = 0; i < zombiesInRange.Count; i++)
        {
            if (zombiesInRange[i] != null)
            {
                zombiesInRange[i].GetComponent<Zombie>().TakeDamage(damage);
            }
            else
            {
                targetsToRemove.Add(i);
            }
        }
        for (int i = targetsToRemove.Count; i > 0; i--)
        {
            zombiesInRange.Remove(zombiesInRange[targetsToRemove[i - 1]]);
        }
    }
}
