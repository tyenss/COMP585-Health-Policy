using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineGameplayDependencies : MonoBehaviour
{
    #region Serialized.
    /// <summary>
    /// 
    /// </summary>
    [Tooltip("Canvas for spawning.")]
    [SerializeField]
    private SpawningCanvas _spawningCanvas;
    /// <summary>
    /// Canvas for spawning.
    /// </summary>
    public static SpawningCanvas SpawningCanvas { get { return _instance._spawningCanvas; } }
    #endregion


    #region Private.
    /// <summary>
    /// Singleton instance of this script.
    /// </summary>
    private static OfflineGameplayDependencies _instance;
    #endregion
    void Awake()
    {
        _instance = this;
    }

   
}
