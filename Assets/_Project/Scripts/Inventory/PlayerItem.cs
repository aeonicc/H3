﻿using System.Collections;
using System.Collections.Generic;
using MoralisUnity;
using UnityEngine;

namespace M
{

    public class PlayerItem : InventoryItem
    {
        public void OnItemClicked()
        {
            MoralisTools.CheckNftOnOpenSea(GameManager.ContractAddress, GameManager.ContractChain.ToString(), GetId());
        }
    }
}