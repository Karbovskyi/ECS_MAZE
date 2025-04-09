
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
    void LoadAll();
    
    int GetMapWidth();
    int GetMapHeight();
    
  }
}