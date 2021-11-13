using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace fightinggame
{
    // Klasser som beskriverk objekt för att serialisera och deserialisera "properties.json".
    public class User
    {
        public Player player { get; set; }
    }
    public class Player
    {
        public string name { get; set; }
        public int health { get; set; }
        public int max_damage { get; set; }
        public int min_damage { get; set; }
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
    }



    public class Level
    {
        public bool level1 { get; set; }
        public bool level2 { get; set; }
        public bool level3 { get; set; }
        public bool level4 { get; set; }
        public bool level5 { get; set; }
        public bool level6 { get; set; }
        public bool level7 { get; set; }
        public bool level8 { get; set; }
        public bool level9 { get; set; }
        public bool level10 { get; set; }
    }
}