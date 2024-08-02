using UnityEngine;

namespace Peeper.Behaviour
{
    internal class PeeperBehaviour : LookoutBehaviour
    {
        private Animator animator;
        public override void Start()
        {
            base.Start();
            maximumRange = 60;
            animator = GetComponent<Animator>();
        }

        protected override void SetActive(bool enable)
        {
            base.SetActive(enable);
            animator.SetBool("Grounded", enable);
        }
    }
}
