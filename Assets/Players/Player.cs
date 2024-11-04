using System.Collections;
using UnityEngine;

namespace Players
{
    public enum PlayerTeam
    {
        TeamA,
        TeamB
    }

    public enum PlayerStatus
    {
        Normal,
        Stun,
        AirBone,
        Dead
    }
    public class Player : MonoBehaviour
    {
        [Header("플레이어 팀")] public PlayerTeam team;
        [Header("플레이어 모션")] public Animator ani;
        [Header("이속")]
        public float moveSpeed;
        [Header("체력")]
        public float maxHp;
        [Header("궁극기 게이지")]
        public float ultimateGauge;
        [Header("스턴시간")]
        public float stunTime;
        [Header("플레이어 리지드 바디")]
        public Rigidbody2D rb;
        [Header("플레이어 히트박스")]
        public Collider2D hitBox;
        [Header("플레이어 데미지 박스 순서데로 q, e, r")] public Collider2D[] damageBox;
        [Header("플레이어 블록/패링 박스 순서데로 블록 ,패링")] public Collider2D[] blockBox = new Collider2D[2];
        [Header("점프하는 힘")] public float jumpForce;
        [Header("플레이어 상태")] public PlayerStatus playerStatus;
        private float _currentUltimateGauge;
        private float _currentHp;
        private float _currentStunTime;

        protected void SetUpPlayer()
        {
            _currentHp = maxHp;
            _currentStunTime = stunTime;
            _currentUltimateGauge = 0;
            playerStatus = PlayerStatus.Normal;
        }
        protected void CheckStatus()
        {
            
        }

        public void Stun(float force, float time)
        {
            
            StartCoroutine(StunFlow(force, time));
        }

        public void AirBone(float force, float time)
        {
            if (playerStatus != PlayerStatus.AirBone)
            {
                StartCoroutine(AirBoneFlow(force, time));
            }
        }
        protected IEnumerator StunFlow(float force, float time)
        {
            rb.velocity = new Vector2(0, 0);
            playerStatus = PlayerStatus.Stun;
            rb.AddForce(rb.transform.right * (force*-1),ForceMode2D.Impulse);
            yield return new WaitForSeconds(time);
            playerStatus = PlayerStatus.Normal;
        }
        protected IEnumerator AirBoneFlow(float force, float time)
        {
            rb.velocity = new Vector2(0, 0);
            playerStatus = PlayerStatus.AirBone;
            rb.AddForce(rb.transform.right * (force*-1),ForceMode2D.Impulse);
            rb.AddForce(Vector2.up*force,ForceMode2D.Impulse);
            yield return new WaitForSeconds(time);
            playerStatus = PlayerStatus.Normal;
        }
        protected void CheckSkill()
        {
            if (team == PlayerTeam.TeamA)
            {
                ASkillSet();
            }
            else
            {
                BSkillSet();
            }
        }

        protected void CheckMovement()
        {
            if (team == PlayerTeam.TeamA)
            {
                AMove();
            }
            else
            {
                BMove();
            }
        }

        protected void AMove()
        {
            if (playerStatus != PlayerStatus.Normal) return;
            var horizontal = 0;
            if (Input.GetKey(KeyCode.A))
            {
                horizontal = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                horizontal = 1;
            }

            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        }

        protected void ASkillSet()
        {
            if (playerStatus == PlayerStatus.Normal)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    DefaultSkill();
                }
                else if(Input.GetKeyDown(KeyCode.E))
                {
                    AbilitySkill();
                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
                    UltimateSkill();
                }
                else if(Input.GetKeyDown(KeyCode.F))
                {
                    BlockSkill();
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    rb.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
                }
            }

        }

        protected void BSkillSet()
        {
            if (playerStatus == PlayerStatus.Normal)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    DefaultSkill();
                }
                else if (Input.GetKeyDown(KeyCode.I))
                {
                    AbilitySkill();
                }
                else if (Input.GetKeyDown(KeyCode.O))
                {
                    UltimateSkill();
                }
                else if (Input.GetKeyDown(KeyCode.L))
                {
                    BlockSkill();
                }

                if (Input.GetKeyDown(KeyCode.U))
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }
        }

        public virtual void DefaultSkill()
        {
            Debug.Log(team+"used defaultskill");
        }

        public virtual void AbilitySkill()
        {
            Debug.Log(team+"used abilityskill");
        }

        public virtual void BlockSkill()
        {
            Debug.Log(team+"used blockskill");
        }

        public virtual void UltimateSkill()
        {
            Debug.Log(team+"used ultimateskill");
        }
        protected void BMove()
        {
            if (playerStatus != PlayerStatus.Normal) return;
            var horizontal = 0;
            if (Input.GetKey(KeyCode.H))
            {
                horizontal = -1;
            }
            else if (Input.GetKey(KeyCode.K))
            {
                horizontal = 1;
            }

            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        }
    }
}
