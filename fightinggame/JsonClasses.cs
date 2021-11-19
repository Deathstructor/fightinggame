using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace fightinggame
{
    // Klasser som beskriver objekt för att serialisera och deserialisera "properties.json" eller savegames.
    public class User
    {
        public Player player { get; set; }
    }
    public class Player
    {
        public string name { get; set; }
        public int health { get; set; }
        public int gold { get; set; }
        public int level { get; set; }
    }



    public class EnemyTypes
    {
        [JsonPropertyName("enemies")]
        public EnemyCollection enemy { get; set; }
    }
    public class EnemyCollection
    {
        public List<Enemy> enemy { get; set; }
    }
    public class Enemy
    {
        public string name { get; set; }
        public int health { get; set; }
        public int max_damage { get; set; }
        public int min_damage { get; set; }
        public double accuracy { get; set; }
        public string type { get; set; }
        public int max_gold_drop { get; set; }
        public int min_gold_drop { get; set; }
    }



    public class Types
    {
        public Player player { get; set; }
        [JsonPropertyName("enemies")]
        public EnemyCollection enemy { get; set; }
    }



    public class Shop
    {
        [JsonPropertyName("shop")]
        public ShopCollection spellItems { get; set; }
        public ShopCollection weaponItems { get; set; }
    }
    public class ShopCollection
    {
        public List<Spells> spellItems { get; set; }
        public List<Weapons> weaponItems { get; set; }

    }
    public class Spells
    {
        public string name { get; set; }
        public int health { get; set; }
        public int damage { get; set; }
        public double crit_multiplier { get; set; }
        public double gold_multiplier { get; set; }
        public int inventory { get; set; }
        public string description { get; set; }
    }
    public class Weapons
    {
        public string name { get; set; }
        public int max_damage { get; set; }
        public int min_damage { get; set; }
        public double accuracy { get; set; }
        public int price { get; set; }
        public bool owned { get; set; }
        public string description { get; set; }
    }
}