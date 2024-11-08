using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Players
{
    public class PlayerFoot : MonoBehaviour
    {
        public Player player;

        private void OnTriggerEnter2D(Collider2D other)
        {
            player.ani.SetInteger("behave",0);
            player._isAttacking = false;
            //Debug.Log("!");
        }
        /*private void OnTriggerStay2D(Collider2D other)
        {
            player.ani.SetInteger("behave",0);
        }*/
        
        private void OnTriggerExit(Collider other)
        {
            player.ani.SetInteger("bahave",2);
        }
    }
}
