using UnityEngine;

namespace Players
{
    public class Ignite : Player
    {
        private void Start()
        {
            SetUpPlayer();
        }

        private void Update()
        {
       
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Stun(3,0.5f,-1);
            }
            CheckFloor();
            CheckSkill();
        }

        private void FixedUpdate()
        {
            CheckMovement();
        }

        public override void DefaultSkill()
        {
            Debug.Log("used puppet skill");
        }
        public override void AbilitySkill()
        {
            Debug.Log("used puppet skill");
        }
        public override void UltimateSkill()
        {
            Debug.Log("used puppet skill");
        }
        public override void BlockSkill()
        {
            Debug.Log("used puppet skill");
        }
    }
}
