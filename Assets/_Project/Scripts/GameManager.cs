using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using TMPro;

using MoralisUnity;
using MoralisUnity.Platform.Objects;
using MoralisUnity.Platform.Queries;

using Nethereum.Hex.HexTypes;
using UnityEngine.SceneManagement;

using MoralisUnity.Web3Api.Models;
using Pixelplacement;

using UnityEngine.InputSystem;

using MoralisUnity.Platform.Queries.Live;

using MoralisUnity.Sdk.Interfaces;


using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using MoralisUnity;
using MoralisUnity.Platform.Objects;
using MoralisUnity.Platform.Services.ClientServices;
using MoralisUnity.Web3Api.Models;


//using MoralisUnity.Platform.Services.ClientServices.MoralisLiveQueryClient<T>;

namespace M
{
    public class MoriaGatesEvent : MoralisObject
    {
        public bool result { get; set; }
        
        public MoriaGatesEvent() : base("MoriaGatesEvent") {}
    }
    
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        public GameObject objectNFT;

        //Smart Contract Data
        public const string ContractAddress = "0xd9145CCE52D386f254917e481eB44e9943F39138";
        public const string ContractAbi = "[{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"account\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"ApprovalForAll\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"previousOwner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"OwnershipTransferred\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256[]\",\"name\":\"ids\",\"type\":\"uint256[]\"},{\"indexed\":false,\"internalType\":\"uint256[]\",\"name\":\"values\",\"type\":\"uint256[]\"}],\"name\":\"TransferBatch\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"id\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"TransferSingle\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"string\",\"name\":\"value\",\"type\":\"string\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"id\",\"type\":\"uint256\"}],\"name\":\"URI\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_tokenId\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"_tokenUrl\",\"type\":\"string\"},{\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"buyItem\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"renounceOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256[]\",\"name\":\"ids\",\"type\":\"uint256[]\"},{\"internalType\":\"uint256[]\",\"name\":\"amounts\",\"type\":\"uint256[]\"},{\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"safeBatchTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"id\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"},{\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"setApprovalForAll\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"transferOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"account\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"id\",\"type\":\"uint256\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address[]\",\"name\":\"accounts\",\"type\":\"address[]\"},{\"internalType\":\"uint256[]\",\"name\":\"ids\",\"type\":\"uint256[]\"}],\"name\":\"balanceOfBatch\",\"outputs\":[{\"internalType\":\"uint256[]\",\"name\":\"\",\"type\":\"uint256[]\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"account\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"}],\"name\":\"isApprovedForAll\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"owner\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"bytes4\",\"name\":\"interfaceId\",\"type\":\"bytes4\"}],\"name\":\"supportsInterface\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"id\",\"type\":\"uint256\"}],\"name\":\"uri\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";

        #region SHOP_STATE

        public static ChainList ContractChain = ChainList.mumbai;
        
        public enum State
        {
            Authenticating,
            Free,
            Inventory,
            Transacting,
        }

        [SerializeField]
        private State _currentState;

        #endregion

        #region WEB3_SPACE
        
        
        public static Action AllEnemiesDead;

        [Header("Control Variables")]
        [SerializeField] private int desiredEnemyCount;
        private int _currentAliveEnemiesCount;
        
        [Header("Enemy Prefabs")]
        [SerializeField] private GameObject bossPrefab;
        [SerializeField] private GameObject enemyPrefab;
        
        [Header("Spawn Corners")]
        [SerializeField] private Transform leftCorner;
        [SerializeField] private Transform rightCorner;
        [SerializeField] private Transform topCorner;

        [Header("UI Panels")]
        [SerializeField] private GameObject hudPanel;
        [SerializeField] private GameObject gameOverPanel;

        [Header("Moralis Mug")]
        [SerializeField] private GameObject moralisMug;

        //Moralis Database
        private MoralisQuery<EnemyData> _allEnemiesQuery;
        private MoralisLiveQueryCallbacks<EnemyData> _enemyCallbacks;
        
        
        
        #endregion

        //Database Queries
        private MoralisQuery<MoriaGatesEvent> _getEventsQuery;
        private MoralisLiveQueryCallbacks<MoriaGatesEvent> _queryCallbacks;
        
        [Header("Main Elements")]
        [SerializeField] private PasswordPanel passwordPanel;
        [SerializeField] private GameObject correctPanel;
        [SerializeField] private GameObject incorrectPanel;
        
        [Header("Other")]
        [SerializeField] private TextMeshProUGUI statusLabel;

        private bool _listening;
        
        // Only for Editor using
        private bool _responseReceived;
        private bool _responseResult;
        

        #region UNITY_LIFECYCLE

        private void Awake()
        {
            Instance = this;
            
            statusLabel.text = string.Empty;
            
            _currentState = State.Authenticating;

            //shop
        //    _input = new GameInputActions();
        //    _input.General.Enable();
        }
        
        
        private void OnEnable()
        {
            MoralisAuthenticator.Authenticated += OnAuthenticationSuccessfulHandler;
            Inventory.Opened += OnInventoryOpenedHandler;
            Inventory.Closed += OnInventoryClosedHandler;
        
            PurchaseItemManager.PurchaseStarted += OnPurchaseStartedHandler;
            PurchaseItemManager.PurchaseCompleted += OnPurchaseCompletedHandler;
            PurchaseItemManager.PurchaseFailed += OnPurchaseFailedHandler;
        
        //    _input.General.Logout.performed += OnLogoutHandler;
        //    _input.General.Quit.performed += OnQuitHandler;
        
        
        //LiveQuery Callbacks that we subscribe to when we have logged in to Moralis.
        _enemyCallbacks = new MoralisLiveQueryCallbacks<EnemyData>();

        _enemyCallbacks.OnCreateEvent += ((item, requestId) => {
                
        });
        _enemyCallbacks.OnUpdateEvent += ((item, requestId) => {
                
        });
        _enemyCallbacks.OnDeleteEvent += ((item, requestId) =>
        {
            if (_currentAliveEnemiesCount == 0) return;

            _currentAliveEnemiesCount--;
            Debug.Log("Current alive enemies = " + _currentAliveEnemiesCount);
        });

        MoralisWeb3Manager.LoggedInSuccessfully += StartGameLoop;
        PlayerControllerSpace.Dead += GameOver;
        Enemy.Dead += OnEnemyDead;
        Boss.Dead += OnBossDead;
            
        //We make sure MoralisMug is not enabled.
        moralisMug.SetActive(false);
        }
        
        private void OnDisable()
        {
            MoralisWeb3Manager.LoggedInSuccessfully -= StartGameLoop;
            PlayerControllerSpace.Dead -= GameOver;
            Enemy.Dead -= OnEnemyDead;
            Boss.Dead -= OnBossDead;
        }
        
        private void OnApplicationQuit()
        {
            //This only executes when we stop playing on the Editor.
        #if UNITY_EDITOR
            if (_currentAliveEnemiesCount == 0) return;

            DeleteAllEnemiesData();
        #endif
        }
        
        
        
        
        #region PUBLIC_METHODS_SHOP

        public State GetCurrentState()
        {
            return _currentState;
        }

        #endregion


        #region EVENT_HANDLERS_SHOP

        private void OnAuthenticationSuccessfulHandler()
        {
            _currentState = State.Free;
        }
    
        private void OnInventoryOpenedHandler()
        {
            _currentState = State.Inventory;
        }

        private void OnInventoryClosedHandler()
        {
            _currentState = State.Free;
        }
    
        private void OnPurchaseStartedHandler()
        {
            _currentState = State.Transacting;
        }

        private void OnPurchaseCompletedHandler(string purchasedItemId)
        {
            _currentState = State.Free;
        }

        private void OnPurchaseFailedHandler()
        {
            _currentState = State.Free;
        }
    
        //private void OnLogoutHandler(InputAction.CallbackContext context)
        //{
       //     _currentState = State.Authenticating;
        //}
    
        //private void OnQuitHandler(InputAction.CallbackContext context)
        //{
        //    Application.Quit();    
        //}

        #endregion
        

        private void Update()
        {
            // We only do this in Editor because of single threading and UI elements issues
            if (!Application.isEditor) return;
            
            if (_responseReceived)
            {
                ShowResponsePanel(_responseResult);
                _responseReceived = false;
            }
        }

        #endregion

   
        
        #region AUTHENTICATIONKIT_HANDLERS

        public void StartGame()
        { 
            SubscribeToDatabaseEvents();
            passwordPanel.gameObject.SetActive(true);
        }
        
        public void ResetGame()
        {
            passwordPanel.gameObject.SetActive(false);
            correctPanel.gameObject.SetActive(false);
            incorrectPanel.gameObject.SetActive(false);
            statusLabel.text = string.Empty;
            
            MoralisLiveQueryController.RemoveSubscriptions("MoriaGatesEvent");
        }

        #endregion

        
        #region PUBLIC_METHODS

        public async void OpenGates()
        {
            statusLabel.text = "Please confirm transaction in your wallet";
            
            var response = await CallContractFunction(passwordPanel.passwordInput.text);

            if (response == null)
            {
                statusLabel.text = "Contract call failed";
                return;
            }
            
            statusLabel.text = "Waiting for contract event...";
            passwordPanel.gameObject.SetActive(false);

            _listening = true;
        }

        #endregion
        

        #region PRIVATE_METHODS

        private async void SubscribeToDatabaseEvents()
        {
            _getEventsQuery = await Moralis.GetClient().Query<MoriaGatesEvent>();
            _queryCallbacks = new MoralisLiveQueryCallbacks<MoriaGatesEvent>();

            _queryCallbacks.OnUpdateEvent += HandleContractEventResponse;

            MoralisLiveQueryController.AddSubscription<MoriaGatesEvent>("MoriaGatesEvent", _getEventsQuery, _queryCallbacks);
        }

        private async UniTask<string> CallContractFunction(string inputPassword)
        {
            object[] parameters = {
                inputPassword
            };

            // Set gas estimate
            HexBigInteger value = new HexBigInteger(0);
            HexBigInteger gas = new HexBigInteger(0);
            HexBigInteger gasPrice = new HexBigInteger(0);

            string resp = await Moralis.ExecuteContractFunction(ContractAddress, ContractAbi, "openGates", parameters, value, gas, gasPrice);
            
            return resp;
        }

        private void HandleContractEventResponse(MoriaGatesEvent newEvent, int requestId)
        {
            if (!_listening) return;

            // You will find this a bit different from the video. It's a quality improvement for Editor testing. Functionality continues in ShowResponsePanel() :)
            if (Application.isEditor)
            {
                _responseResult = newEvent.result;
                _responseReceived = true;

                return;
            }

            ShowResponsePanel(newEvent.result);
        }

        private void ShowResponsePanel(bool isCorrect)
        {
            if (isCorrect)
            {
                correctPanel.SetActive(true);
                Debug.Log("Correct password");
            }
            else
            {
                incorrectPanel.SetActive(true);
                Debug.Log("Incorrect password");
            }

            statusLabel.text = string.Empty;
            _listening = false;

            StartCoroutine(DoSomething(isCorrect));
        }

        private IEnumerator DoSomething(bool result)
        {
            yield return new WaitForSeconds(3f);

            if (result)
            {
                //We could load another game scene here
                SceneManager.LoadScene("Main");
            }
            else
            {
                //Make the user type the password again
                incorrectPanel.SetActive(false);
                passwordPanel.gameObject.SetActive(true);
            }
        }

        #endregion
        
        
        #region GAME_LOOP

        private IEnumerator GameLoop()
        {
            yield return StartCoroutine(GeneratingEnemies());
            
            yield return StartCoroutine(EnemiesRound());

            yield return StartCoroutine(BossRound());
            
            yield return StartCoroutine(AwardTime());
        }
        
        private IEnumerator GeneratingEnemies()
        {
            GenerateEnemies();
            
            //We stay here while all the enemies are being generated.
            while (_currentAliveEnemiesCount != desiredEnemyCount)
            {
                yield return null;
            }
        }
        
        private IEnumerator EnemiesRound()
        {
            if (desiredEnemyCount <= 0)
            {
                yield break;
            }

            //While there are some enemies left we stay here.
            while (_currentAliveEnemiesCount > 0)
            {
                yield return null;
            }
            
            AllEnemiesDead?.Invoke();
        }
        
        private IEnumerator BossRound()
        {
            Debug.Log("NO ENEMIES LEFT!");
            
            //Instantiate Boss
            var boss = Instantiate(bossPrefab, Vector3.zero, Quaternion.identity);
            
            // While boss is alive...
            while (boss.gameObject != null)
            {
                yield return null;
            }
            
            Debug.Log("BOSS DESTROYED!");
        }
        
        private IEnumerator AwardTime()
        {
            yield return null;
            
            Debug.Log("Time to claim the NFT!");
        }

        #endregion
        
          #region EVENT_HANDLERS
        
        private void StartGameLoop()
        {
            //IMPORTANT: We create a query to get ALL the EnemyData objects. We will use this query in multiple methods.
            //_allEnemiesQuery = Moralis.GetClient().Query<EnemyData>();
            
            //_allEnemiesQuery =  Moralis.GetClient().Query<EnemyData>(); 
           
                

            //We add a SUBSCRIPTION to that query so we get callback when something happens (object created, deleted, etc.).
            MoralisLiveQueryController.AddSubscription("EnemyData", _allEnemiesQuery, _enemyCallbacks);
            
            hudPanel.SetActive(true);
            StartCoroutine(GameLoop());
        }

        private void GameOver()
        {
            hudPanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }
        
        private void OnEnemyDead(string deadEnemyId)
        {
            DeleteEnemyDataByObjectId(deadEnemyId);
        }

        private void OnBossDead(Vector3 bossLastPosition)
        {
            //Now MoralisMugNFT script takes care of everything.
            moralisMug.transform.position = bossLastPosition;
            moralisMug.SetActive(true);

            hudPanel.SetActive(false);
        }

        #endregion
        
        #region PRIVATE_METHODS

        private async void GenerateEnemies()
        {
            //For the enemy count that we choose...
            for (int i = 0; i < desiredEnemyCount; i++)
            {
                //We first calculate a random instantiation position between our spawn points.
                float xPos = UnityEngine.Random.Range(leftCorner.position.x, rightCorner.position.x);
                float yPos = UnityEngine.Random.Range(leftCorner.position.y, topCorner.position.y);
                float zPos = UnityEngine.Random.Range(leftCorner.position.z, rightCorner.position.z);
                
                var instantiationPos = new Vector3(xPos, yPos, zPos);
                
                //Then we create the EnemyData object.
                EnemyData enemyDb = Moralis.GetClient().Create<EnemyData>();
                
                //And we set the calculated position.
                enemyDb.initPosition = new List<float>
                {
                    instantiationPos.x,
                    instantiationPos.y,
                    instantiationPos.z
                };
                
                //We set a random multiplier for each enemy to have different speed and size.
                var randomMultiplier = UnityEngine.Random.Range(1f, 3f);
                enemyDb.size *= randomMultiplier;
                enemyDb.speed *= randomMultiplier;

                //Finally we save the object to the DB.
                var success = await enemyDb.SaveAsync();

                //If it's successfully saved, we will Instantiate our local enemy in Unity.
                if (success)
                {
                    var newLocalEnemy = Instantiate(enemyPrefab, instantiationPos, Quaternion.identity);
                    newLocalEnemy.GetComponent<Enemy>().Initialize(enemyDb.objectId, enemyDb.size, enemyDb.speed);
                        
                    _currentAliveEnemiesCount++;
                }
            }
        }

        private async void DeleteAllEnemiesData()
        {
            //We get a "List" of the required objects using the correspondent query.
            IEnumerable<EnemyData> enemies = await _allEnemiesQuery.FindAsync();
            var enemiesList = enemies.ToList();
            
            if (enemiesList.Any())
            {
                //If there are some, we delete them.
                foreach (var enemy in enemiesList)
                {
                    await enemy.DeleteAsync();
                }
            }
            else
            {
                Debug.Log("There ara no EnemyData objects in the DB to delete.");
            }
        }
        
        private async void DeleteEnemyDataByObjectId(string objectId)
        {
            
            
            
            
            
            
            
            //We want to query just one specific object.
            
            //MoralisQuery<EnemyData> query = Moralis.GetClient().Query<EnemyData>().Equals("objectId", objectId);
            
            
            //WhereEqualTo("objectId", objectId); MoralisLiveQueryClient MoralisLiveQueryCallbacks<>
                









            //IEnumerable<EnemyData> enemiesToDelete = await query.FindAsync(); //We will just find one because "objectId" is unique.
            
            
            //var enemiesToDeleteList = enemiesToDelete.ToList();
            //if (enemiesToDeleteList.Any())
            //{
                //If there are some, we delete them.
            //    foreach (var enemy in enemiesToDeleteList)
            //   {
            //       await enemy.DeleteAsync();
                    
                    //The LiveQuery subscription will take care of that. Go check the events on "OnEnable()".
            //  }
            //}
            //else
            //{
            //    Debug.Log("There ara no EnemyData objects in the DB to delete.");
            //}
        }

            
            
        private IEnumerator QuitGame()
        {
            if (_currentAliveEnemiesCount > 0)
            {
                DeleteAllEnemiesData();
            }

            while (_currentAliveEnemiesCount > 0)
            {
                yield return null;
            }
            
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        #endregion

    }
    
}
