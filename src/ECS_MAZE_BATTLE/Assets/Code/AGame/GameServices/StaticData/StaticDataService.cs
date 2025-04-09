
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public class StaticDataService : IStaticDataService
  {

    private MapConfig _mapConfig;

    public void LoadAll()
    {
      LoadMapConfig();
    }
    
    public int GetMapWidth() => _mapConfig.Width;

    public int GetMapHeight() => _mapConfig.Height;
    
    private void LoadMapConfig()
    { 
      _mapConfig = Resources
        .Load<MapConfig>("Configs/Map/MapConfig");
    }
  }
}