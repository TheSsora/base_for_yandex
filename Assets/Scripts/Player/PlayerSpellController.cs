using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSpellController : MonoBehaviour
{
    [SerializeField] private List<SpellObject> spells;
    [SerializeField] private List<EnemyController> enemies;
    private float _timer;
    
    private void Update()
    {
        
        CooldownSpells();
        if (enemies.Count > 0)
        {
            var spell = SpellSpawn();
            if (spell != null)
            {
                if (spell is IDirectionSpell directionSpell)
                {
                    directionSpell.SetDirection(enemies[0].transform.position - transform.position);
                }
            }
        }
    }
    private Spell SpellSpawn()
    {
        foreach (var spellObject in spells.Where(x => x.cooldown <= 0))
        {
            spellObject.cooldown = spellObject.spell.Cooldown;
            Instantiate(spellObject.spell.gameObject, new Vector3(transform.position.x, spellObject.spell.transform.position.y, transform.position.z), 
                Quaternion.identity).TryGetComponent(out Spell spell);
            return spell;
        }
        return null;
    }
    private void CooldownSpells()
    {
        spells.Where(x => x.cooldown > 0).ToList().ForEach(x => x.cooldown -= Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyController>(out var enemy))
        {
            enemies.Add(enemy);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<EnemyController>(out var enemy))
        {
            enemies.Remove(enemy);
        }
    }
}
[Serializable]
public class SpellObject
{
    [SerializeField] public Spell spell;
    [SerializeField] public float cooldown;
}
