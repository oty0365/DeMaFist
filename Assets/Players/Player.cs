using UnityEngine;

namespace Players
{
    public class Player : MonoBehaviour
    {
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
        [Header("플레이어 데미지 박스 순서데로 q, e, r")]
        public Collider2D[] damageBox = new Collider2D[3];
        private float _currentUltimateGauge;
        private float _currentHp;
        private float _currentStunTime;
        
        
    }
}
