using System.ComponentModel;
using MarsSettingsGUI;
using SetLootRange;
using wManager.Events;
using wManager.Plugin;
using wManager.Wow.ObjectManager;

public class Main : IPlugin
{
  public void Dispose()
  {
    LootingEvents.OnLootingPulse -= LootingPulse;
  }

  public void Initialize()
  {
    SetLootSettings.Load();
    LootingEvents.OnLootingPulse += LootingPulse;
  }

  private void LootingPulse(WoWUnit unit, CancelEventArgs cancelable)
  {
    if (unit.IsValid && unit.GetDistance > SetLootSettings.CurrentSetting.LootRange)
    {
      Helpers.Logger("Blacklist Mobs " + unit.Name + " Distance " + unit.GetDistance);
      wManager.wManagerSetting.AddBlackList(unit.Guid, 30 * 1000);
      cancelable.Cancel = true;
    }
  }

  public void Settings()
  {
    SetLootSettings.Load();
    new SettingsWindow(SetLootSettings.CurrentSetting).ShowDialog();
    SetLootSettings.CurrentSetting.Save();
  }
}

