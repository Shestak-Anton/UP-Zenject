using UnityEngine;

namespace GameContext.Config
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        [field: SerializeField] public int MaxLevelCount { private set; get; }        
    }
}