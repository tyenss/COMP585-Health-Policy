using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    public class PlayerInstance : NetworkBehaviour
    {

        #region Public.
        /// <summary>
        /// Dispatched when this player instance is set as the local player.
        /// </summary>
        public static event Action<PlayerInstance> OnPlayerInstance;
        #endregion

        #region Serialized
        /// <summary>
        /// PlayerSpawner on this object.
        /// </summary>
        public PlayerSpawner PlayerSpawner { get; private set; }
        #endregion

        /// <summary>
        /// /// Called when the local player object has been set up.
        /// </summary>
        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();
            PlayerSpawner = GetComponent<PlayerSpawner>();

            OnPlayerInstance?.Invoke(this);
        }

    }


