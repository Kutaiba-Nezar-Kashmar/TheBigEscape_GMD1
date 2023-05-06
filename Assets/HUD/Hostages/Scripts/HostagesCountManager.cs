using System;
using TMPro;
using UnityEngine;

namespace HUD.Hostages.Scripts
{
    public class HostagesCountManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI hostagesText;
        private void Update()
        {
            var myPrefabObjects = GameObject.FindGameObjectsWithTag("NPC");
            var numberOfMyPrefab = myPrefabObjects.Length;
            hostagesText.text = $"Hostages: {numberOfMyPrefab}";
        }
    }
}