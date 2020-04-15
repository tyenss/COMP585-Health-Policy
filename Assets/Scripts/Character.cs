using Mirror;
using System.Collections;
using UnityEngine;



    public class Character : NetworkBehaviour
    {
        private void OnDestroy()
        {
            //Run in addition to isServer, for client host.
            if (base.isClient && base.hasAuthority)
                OfflineGameplayDependencies.SpawningCanvas.Show();
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            if (!base.hasAuthority && base.isServer)
                StartCoroutine(__SelfDestruct(3f));
        }

        /// <summary>
        /// Self destructs on the server.
        /// </summary>
        [Server]
        private IEnumerator __SelfDestruct(float delay)
        {
            yield return new WaitForSeconds(delay);
            NetworkServer.Destroy(gameObject);
        }

    }


