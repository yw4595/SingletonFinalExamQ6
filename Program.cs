using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

// Author: Yanzhi Wang
// Purpose: Represents the player's settings, including the player's name, level, HP, inventory, and license key.
// Restrictions: None
public class PlayerSettings
{
    public string PlayerName { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public List<string> Inventory { get; set; }
    public string LicenseKey { get; set; }

    private static PlayerSettings instance = null;

    // private constructor to prevent other classes from creating instances
    private PlayerSettings()
    {
        // initialize default values
        PlayerName = "dschuh";
        Level = 4;
        HP = 99;
        Inventory = new List<string>()
        {
            "spear",
            "water bottle",
            "hammer",
            "sonic screwdriver",
            "cannonball",
            "wood",
            "Scooby snack",
            "Hydra",
            "poisonous potato",
            "dead bush",
            "repair powder"
        };
        LicenseKey = "DFGU99-1454";
    }

    // returns the single instance of PlayerSettings
    public static PlayerSettings Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerSettings();
            }
            return instance;
        }
    }

    // saves the settings to a JSON file
    public void SaveSettings(string filePath)
    {
        string json = JsonConvert.SerializeObject(this);
        File.WriteAllText(filePath, json);
    }

    // loads the settings from a JSON file
    public void LoadSettings(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerSettings settings = JsonConvert.DeserializeObject<PlayerSettings>(json);
            instance = settings;
        }
        else
        {
            Console.WriteLine("Settings file not found.");
        }
    }
}

// Author: Yanzhi Wang
// Purpose: Provides a console application that demonstrates the usage of the PlayerSettings class.
class Program
{
    static void Main(string[] args)
    {
        string filePath = "player_settings.json";

        // save settings to file
       PlayerSettings.Instance.SaveSettings(filePath);
       // Console.WriteLine("Settings saved to file.");

        // load settings from file
        PlayerSettings.Instance.LoadSettings(filePath);
        Console.WriteLine("Settings loaded from file:");

        Console.WriteLine("Player Name: " + PlayerSettings.Instance.PlayerName);
        Console.WriteLine("Level: " + PlayerSettings.Instance.Level);
        Console.WriteLine("HP: " + PlayerSettings.Instance.HP);
        Console.WriteLine("Inventory: " + string.Join(",", PlayerSettings.Instance.Inventory));
        Console.WriteLine("License Key: " + PlayerSettings.Instance.LicenseKey);
    }
}
