
using System;
using System.Collections;
using System.Collections.Generic;
//using Moralis.Platform.Objects;
//using Moralis.Platform.Queries;
using UnityEngine;
using TMPro;

//MORALIS & WALLET CONNECT
//using MoralisWeb3ApiSdk;
using WalletConnectSharp.Core.Models;
using WalletConnectSharp.Unity;

using MoralisUnity.Platform.Objects;
using MoralisUnity.Platform.Queries;
using MoralisUnity.Web3Api;


using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using MoralisUnity;
using MoralisUnity.Platform.Objects;
using MoralisUnity.Web3Api.Models;
using UnityEngine;

using Nethereum.Hex.HexTypes;


namespace M
{
    public class MoralisWeb3Manager : MonoBehaviour
    {
        public static Action LoggedInSuccessfully;
        public bool isDebug;
        
        [Header("Moralis and WalletConnect")]
        //[SerializeField] private MoralisController moralisController;
        [SerializeField] private WalletConnect walletConnect;

        [Header("Login Panels")] 
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private GameObject qrPanel;

        [Header("Other UI Elements")] 
        [SerializeField] private TextMeshProUGUI debugLabel;
        
        
        private string MUG_CONTRACT_ADDRESS = "0x05af21b57d2E378F90106B229E717DC96c7Bb5e2";
        private string MUG_CHAIN = "mumbai";
        private string MUG_CLAIM_FUNCTION = "claimReward";
        private string MUG_ABI = "[{\"inputs\":[{\"internalType\":\"address\",\"name\":\"nftContractAddress\",\"type\":\"address\"}],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"account\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"ApprovalForAll\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"previousOwner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"OwnershipTransferred\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256[]\",\"name\":\"ids\",\"type\":\"uint256[]\"},{\"indexed\":false,\"internalType\":\"uint256[]\",\"name\":\"values\",\"type\":\"uint256[]\"}],\"name\":\"TransferBatch\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"id\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"TransferSingle\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"string\",\"name\":\"value\",\"type\":\"string\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"id\",\"type\":\"uint256\"}],\"name\":\"URI\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"account\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"id\",\"type\":\"uint256\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address[]\",\"name\":\"accounts\",\"type\":\"address[]\"},{\"internalType\":\"uint256[]\",\"name\":\"ids\",\"type\":\"uint256[]\"}],\"name\":\"balanceOfBatch\",\"outputs\":[{\"internalType\":\"uint256[]\",\"name\":\"\",\"type\":\"uint256[]\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"id\",\"type\":\"uint256\"}],\"name\":\"claimReward\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"account\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"}],\"name\":\"isApprovedForAll\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"id\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"url\",\"type\":\"string\"},{\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"mint\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"},{\"internalType\":\"uint256[]\",\"name\":\"\",\"type\":\"uint256[]\"},{\"internalType\":\"uint256[]\",\"name\":\"\",\"type\":\"uint256[]\"},{\"internalType\":\"bytes\",\"name\":\"\",\"type\":\"bytes\"}],\"name\":\"onERC1155BatchReceived\",\"outputs\":[{\"internalType\":\"bytes4\",\"name\":\"\",\"type\":\"bytes4\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"},{\"internalType\":\"bytes\",\"name\":\"\",\"type\":\"bytes\"}],\"name\":\"onERC1155Received\",\"outputs\":[{\"internalType\":\"bytes4\",\"name\":\"\",\"type\":\"bytes4\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"owner\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"renounceOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256[]\",\"name\":\"ids\",\"type\":\"uint256[]\"},{\"internalType\":\"uint256[]\",\"name\":\"amounts\",\"type\":\"uint256[]\"},{\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"safeBatchTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"id\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"},{\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"setApprovalForAll\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"bytes4\",\"name\":\"interfaceId\",\"type\":\"bytes4\"}],\"name\":\"supportsInterface\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"transferOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"contractAddress\",\"type\":\"address\"}],\"name\":\"updateTargetContract\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"uri\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";
    

        #region UNITY_LIFECYCLE

        private async void Start()
        {
            //We just want to test the game
            if (isDebug)
            {
                mainPanel.SetActive(false);
                LoggedInSuccessfully?.Invoke();
                this.gameObject.SetActive(false);
                return;
            }
            /*
            if (moralisController != null && moralisController)
            {
                await moralisController.Initialize();
            }
            else
            {
                Debug.LogError("The MoralisInterface has not been set up, please check you MoralisController in the scene.");
                return;
            }
*/
            debugLabel.text = "Scan QR Code to Login";
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                LogOut();
            }
        }

        #endregion

        #region WALLET_LOGIN_METHODS

        public async void WalletConnectHandler(WCSessionData data)
        {
            Debug.Log("Wallet connection received");
            debugLabel.text = "Wallet connected";
            
            // Extract wallet address from the Wallet Connect Session data object.
            string address = data.accounts[0].ToLower();
            string appId = Moralis.GetClient().ApplicationId;
            long serverTime = 0;

            // Retrieve server time from Moralis Server for message signature
            Dictionary<string, object> serverTimeResponse = await Moralis.GetClient().Cloud.RunAsync<Dictionary<string, object>>("getServerTime", new Dictionary<string, object>());

            if (serverTimeResponse == null || !serverTimeResponse.ContainsKey("dateTime") ||
                !long.TryParse(serverTimeResponse["dateTime"].ToString(), out serverTime))
            {
                Debug.Log("Failed to retrieve server time from Moralis Server!");
                debugLabel.text = "Failed to retrieve server time from Moralis Server";
            }

            string signMessage = $"Moralis Authentication\n\nId: {appId}:{serverTime}";

            Debug.Log($"Sending sign request for {address} ...");
            debugLabel.text = "Please sign authentication message in your wallet";

            string response = await walletConnect.Session.EthPersonalSign(address, signMessage);

            Debug.Log($"Signature {response} for {address} was returned");

            // Create moralis auth data from message signing response.
            Dictionary<string, object> authData = new Dictionary<string, object> { { "id", address }, { "signature", response }, { "data", signMessage } }; 

            Debug.Log("Logging in user.");
            debugLabel.text = "Logging in user";

            // Attempt to login user.
            var user = await Moralis.LogInAsync(authData);

            if (user != null)
            {
                Debug.Log($"User {user.username} logged in successfully. ");
                debugLabel.text = $"User {user.username} logged in successfully";
                
                mainPanel.SetActive(false);
                LoggedInSuccessfully?.Invoke();
            }
            else
            {
                Debug.Log("User login failed.");
                debugLabel.text = "User login failed";
            }
        }
        
        public void OnWalletConnectedHandler()
        {
            qrPanel.SetActive(false);
        }

        public void WalletConnectSessionEstablished(WalletConnectUnitySession session)
        {
            InitializeWeb3();
        }
        
        private async void LogOut()
        {
            // Disconnect wallet subscription.
            await walletConnect.Session.Disconnect();
            // CLear out the session so it is re-establish on sign-in.
            walletConnect.CLearSession();
            // Logout the Moralis User.
            await Moralis.LogOutAsync();
        }

        #endregion

        #region PRIVATE_METHODS

        private void InitializeWeb3()
        {
            HexBigInteger value = new HexBigInteger(0);
            HexBigInteger gas = new HexBigInteger(0);
            HexBigInteger gasPrice = new HexBigInteger(0);
            HexBigInteger Reward = new HexBigInteger(0);
            
            // RPC Node connection.
            Moralis.SetupWeb3();

            // Create an entry for the Game Rewards Contract.
            Moralis.ExecuteContractFunction(MUG_CONTRACT_ADDRESS, MUG_ABI, "claimReward", null, value, gas, gasPrice);
            //InsertContractInstance("Rewards", Constants.MUG_ABI, Constants.MUG_CHAIN, Constants.MUG_CONTRACT_ADDRESS);
        }

        #endregion
    }
}

