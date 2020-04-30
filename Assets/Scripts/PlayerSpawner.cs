﻿using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine;




    public class PlayerSpawner : NetworkBehaviour
    {
    public Vector3[] pos = new[] { new Vector3(420f, -2800f, 0f), new Vector3(420f, -2800f, 0f), new Vector3(2420f, -2800f, 0f), new Vector3(4420f, -2800f, 0f), new Vector3(6420f, -2800f, 0f), new Vector3(8420f, -2800f, 0f), new Vector3(10420f, -2800f, 0f) };
    
   
    //==420
    
        #region Types.
        [System.Serializable]
        private class CharacterPrefab
        {
            /// <summary>
            /// 
            /// </summary>
            [Tooltip("Prefab to spawn for the character type.")]
            [SerializeField]
            private GameObject _prefab;
            /// <summary>
            /// Prefab to spawn for the character type.
            /// </summary>
            public GameObject Prefab { get { return _prefab; } }
            /// <summary>
            /// Character type the prefab is for.
            /// </summary>
            [Tooltip("Character type the prefab is for.")]
            [SerializeField]
            private CharacterTypes _characterType;
            /// <summary>
            /// Character type the prefab is for.
            /// </summary>
            public CharacterTypes CharacterType { get { return _characterType; } }

        }

        #endregion

        #region Serialized.
        /// <summary>
        /// Prefabs for each character type.
        /// </summary>
        [Tooltip("Prefabs for each character type.")]
        [SerializeField]
        private List<CharacterPrefab> _characterPrefabs = new List<CharacterPrefab>();
        #endregion

        /// <summary>
        /// /// Called when the local player object has been set up.
        /// </summary>
        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();

            //Show the spawning canvas once connected as an local player.
            OfflineGameplayDependencies.SpawningCanvas.Show();
        }

        /// <summary>
        /// Tries to spawn the requested character type.
        /// </summary>
        /// <param name="characterType"></param>
        public void TrySpawn(CharacterTypes characterType)
        {
            CmdTrySpawn((int)characterType);
        }

        /// <summary>
        /// Tries to spawn the specified character type.
        /// </summary>
        /// <param name="characterType"></param>
        [Command]
        private void CmdTrySpawn(int characterType)
        {
            //Convert for readability.
            CharacterTypes characterEnum = (CharacterTypes)characterType;

            int index = _characterPrefabs.FindIndex(x => x.CharacterType == characterEnum);
            //If index isn't found then you likely forgot to setup the character type prefabs.
            if (index == -1)
                return;
            //No prefab set for index, you likely forgot to specify a prefab for the character type.
            if (_characterPrefabs[index].Prefab == null)
                return;

        //Choose a random position.
        GameObject result;
       //type 1 is patient
       if (characterType == 1)
       {
          Vector3 pos1 = new Vector3(UnityEngine.Random.Range(-2f, 500f), 0, 0);
           result = Instantiate(_characterPrefabs[index].Prefab, pos1, Quaternion.Euler(0,180,0));
       }
        else 
        {
        //Vector3 pos = new Vector3(doctorx, -2800f, 0f);
          result = Instantiate(_characterPrefabs[index].Prefab, pos[GlobalVariables.doctorList.Count], Quaternion.Euler(0, 180, 0));
            //GlobalVariables.docIndex ++;
            
       }
            

           

            //Spawn over server giving authority to the client calling this command.
            NetworkServer.Spawn(result, base.netIdentity.connectionToClient);

            //Tell player their character was spawned. Could pass in an object here.
            TargetCharacterSpawned();
        }

        /// <summary>
        /// Notifies a player their character spawned, providing the gameobject of the spawned character.
        /// </summary>
        /// <param name="identity"></param>
        [TargetRpc]
        private void TargetCharacterSpawned()
        {
            OfflineGameplayDependencies.SpawningCanvas.Hide();
        }

    }


