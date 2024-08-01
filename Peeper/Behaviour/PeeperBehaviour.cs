using GameNetcodeStuff;
using System.Collections.Generic;
using UnityEngine;

namespace Peeper.Behaviour
{
    /// <summary>
    /// <para>Item which allows players holding the item to breath underwater, however their vision will be blocked by the model as it will be placed on their head.</para>
    /// </summary>
    internal class PeeperBehaviour : GrabbableObject
    {
        internal const string ITEM_NAME = "Peeper";
        static List<PeeperBehaviour> coilHeadItems = new();
        /// <summary>
        /// Wether the instance of the class can stop coil-heads from moving or not
        /// </summary>
        private bool Active;
        /// <summary>
        /// The Animator component of the instance of the class
        /// </summary>
        private Animator anim;
        protected bool KeepScanNode
        {
            get
            {
                return Plugin.Config.SCAN_NODE;
            }
        }

        public override void Start()
        {
            base.Start();
            anim = GetComponent<Animator>();
            coilHeadItems.Add(this);
        }
        public override void Update()
        {
            base.Update();
            SetActive(!isHeld && !isHeldByEnemy);
        }
        private void SetActive(bool enable)
        {
            Active = enable;
            anim.SetBool("Grounded", enable);
        }

        public bool HasLineOfSightToPosition(Vector3 pos, int range = 60)
        {
            if (!Active) return false;
            float num = Vector3.Distance(transform.position, pos);
            bool result = num < range && !Physics.Linecast(transform.position, pos, StartOfRound.Instance.collidersRoomDefaultAndFoliage, QueryTriggerInteraction.Ignore);
            return result;
        }

        public static bool HasLineOfSightToPeepers(Vector3 springPosition)
        {
            foreach (PeeperBehaviour peeper in coilHeadItems)
            {
                if (peeper == null)
                {
                    coilHeadItems.Remove(peeper);
                    continue;
                }
                if (peeper.HasLineOfSightToPosition(springPosition)) return true;
            }
            return false;
        }
    }
}
