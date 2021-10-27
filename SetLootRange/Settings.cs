using robotManager.Helpful;
using SetLootRange;
using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

public class SetLootSettings : Settings
{

  [Setting]
  [Category("General")]
  [DisplayName("Set Loot Range")]
  [Description("Loot Range")]
  public int LootRange { get; set; }

  private SetLootSettings()
  {
    LootRange = 40;
  }

  public static SetLootSettings CurrentSetting { get; set; }

  public bool Save()
  {
    try
    {
      return Save(AdviserFilePathAndName("SetLootRange", ObjectManager.Me.Name + "." + Usefuls.RealmName));
    }
    catch (Exception ex)
    {
      Helpers.Logger("Error - Save() : " + ex);
      return false;
    }
  }

  public static bool Load()
  {
    try
    {
      if (File.Exists(AdviserFilePathAndName("SetLootRange", ObjectManager.Me.Name + "." + Usefuls.RealmName)))
      {
        CurrentSetting = Load<SetLootSettings>(AdviserFilePathAndName("SetLootRange", ObjectManager.Me.Name + "." + Usefuls.RealmName));
        return true;
      }
      CurrentSetting = new SetLootSettings();
    }
    catch (Exception ex)
    {
      Helpers.Logger("Error - Load() : " + ex);
    }
    return false;
  }

}
