using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
// using Assets.Scripts.Helper;
using System;


    public class TryPickerWheel : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject wheelPiecePrefab ;
        [SerializeField] private GameObject linePrefab ;
        [SerializeField] private GameObject detailsUIPrefab ;
        [SerializeField] private GameObject centerPointPrefab ;


        [Space][Header("Game Object Reference")]
        [SerializeField] private GameObject spinningCircle;
        [SerializeField] private GameObject tranparentRewardBG;

    
        [Space][Header("Transform Referances")]
        [SerializeField] private Transform spawnDetailsTransform ;
        [SerializeField] private Transform wheelPiecesParent ;
        [SerializeField] private Transform linesParent ;
        [SerializeField] private Transform pointer;

        
        [Space][Header("Button and Text References")]
        public Button spinButton ;
        public Button coinSpinButton ;
        // [SerializeField] private TextMeshProUGUI spinText ;

        [Space][Header("Other References")]
        [SerializeField] private int coinsForSpin = 100;
        [SerializeField] private float rotationTime = 5f;
        [SerializeField] private ObjectsInPickerSO[] objectsInPickerSO_Array ;


        
        private List<GameObject> instantiatedLines = new List<GameObject>();
        private List<Transform> newCenterPointTransform = new List<Transform>();

        private float pieceAngle ;
        private float halfPieceAngle ;
        System.Random random = new System.Random();
        private SpinnerUIScript spinnerUI_Script;
        private SpinTimer spinTimer_Script;
        
        [HideInInspector]
        public GameObject detailsUI;

        private void Awake() {
            spinTimer_Script = transform.parent.GetComponentInChildren<SpinTimer>();
            spinnerUI_Script = FindAnyObjectByType<SpinnerUIScript>();

            spinButton.onClick.AddListener(()=>
            {
                spinTimer_Script.StartTimer();
                SpinButtonPressed();
            });
            coinSpinButton.onClick.AddListener(()=>
            {
                if(GetCoins() < coinsForSpin){
                    spinnerUI_Script.ActiveWarningCoinText();
                }else{
                    SpinButtonPressed();
                    // CharacterSelectionUI.coins -= coinsForSpin;
                    SetCoins(-coinsForSpin);
                    spinnerUI_Script.ChangeCoinText();
                    coinSpinButton.gameObject.SetActive(false);
                }
            });
        }

        private void Start() {
            spinTimer_Script.CheckTimerOnStart();
            
            pieceAngle = 360 / objectsInPickerSO_Array.Length;
            halfPieceAngle = pieceAngle / 2f ;
            Generate () ;

            tranparentRewardBG.SetActive(false);
        }
        private void Update() {
            spinTimer_Script.Check24Hours();
        }

        private void SpinButtonPressed(){
            spinButton.interactable = false;
            // spinText.text = "Spinning";
            StartCoroutine(RotatePickerWheel(rotationTime));
        }

        private void Generate(){
            for (int i = 0; i < objectsInPickerSO_Array.Length; i++){
                DrawPiece (i) ;
            }

            pointer.position = instantiatedLines[0].transform.position;
            // pointer.position = instantiatedLines[0].transform.position;
        }

        private void DrawPiece (int index) {
            ObjectsInPickerSO piece = objectsInPickerSO_Array [ index ] ;
            Transform pieceTrns = InstantiatePiece ().transform.GetChild (0) ;

            pieceTrns.GetChild (1).GetComponent <Image> ().sprite = piece.sprite ;
            pieceTrns.GetChild (2).GetComponent <TextMeshProUGUI> ().text = piece.objectName ;
            pieceTrns.GetChild (3).GetComponent <TextMeshProUGUI> ().text = piece.Amount.ToString () ;

            //Line
            Transform lineTrns = Instantiate (linePrefab, linesParent.position, Quaternion.identity, linesParent).transform ;
            Transform centerPoint = Instantiate (centerPointPrefab, lineTrns.position, Quaternion.identity, lineTrns).transform ;

            lineTrns.RotateAround (wheelPiecesParent.position, Vector3.back, (pieceAngle * index) + halfPieceAngle) ;
            centerPoint.RotateAround (wheelPiecesParent.position, Vector3.back, (((pieceAngle*(2/5)) * index)) - (halfPieceAngle)) ;
            pieceTrns.RotateAround (wheelPiecesParent.position, Vector3.back, pieceAngle * index) ;

            instantiatedLines.Add(lineTrns.GetChild (0).gameObject);
            newCenterPointTransform.Add(centerPoint.GetChild(0).gameObject.transform);

        }

        private GameObject InstantiatePiece () {
            return Instantiate (wheelPiecePrefab, wheelPiecesParent.position, Quaternion.identity, wheelPiecesParent) ;
        }

        // Adjust this parameter to control the wheel's rotation speed
        // public float rotationSpeed = 360f;

        IEnumerator RotatePickerWheel(float duration){
            int target = 0;
            target = GetRandomObjectIndex();
            Debug.Log("You will Get Item : "+ (target+1));

            float elapsed = 0.0f;
            float rotSpeed = duration;
            float distance = Vector3.Distance (newCenterPointTransform[target].position, pointer.position);

            while(elapsed < duration-2){
                spinningCircle.transform.Rotate(0, 0, -rotSpeed * Time.deltaTime * 100);
                distance = Vector3.Distance (newCenterPointTransform[target].position, pointer.position);
                rotSpeed -= Time.deltaTime;
                elapsed += Time.deltaTime;
                yield return null; 
            }


            // float elapsedTime = 0f;

            // while (elapsedTime < duration){
            //     // // Calculate the rotation angle based on time and speed
            //     // float rotationAmount = rotationSpeed * Time.deltaTime;
            //     // spinningCircle.transform.Rotate(-Vector3.forward, rotationAmount);

            //     // Update the elapsed time
            //     elapsedTime += Time.deltaTime;

            //     yield return null;
            // }
            // // Adjust the final rotation to align with the target angle
            // float finalRotation = (360/objectsInPickerSO_Array.Length)*target;
            // Debug.Log(finalRotation);
            // spinningCircle.transform.rotation = Quaternion.Euler(0f, 0f, finalRotation);



            while(distance > 10){
                spinningCircle.transform.Rotate(0, 0, -rotSpeed * Time.deltaTime * 100);
                distance = Vector3.Distance (newCenterPointTransform[target].position, pointer.position);
                // Debug.Log(distance);
                yield return null;
            }
            yield return new WaitForSeconds(1f);      
            GenerateDetails(target);

            spinButton.interactable = true;
            // spinText.text = "Spin";
            coinSpinButton.gameObject.SetActive(true);
        }

        private void GenerateDetails(int target)
        {
            InstantiateDetailsUI(target);
            // CharacterSelectionUI.coins += objectsInPickerSO_Array[target].Amount;
            SetCoins(objectsInPickerSO_Array[target].Amount);
            // spinnerUI_Script.ChangeCoinText();

            tranparentRewardBG.SetActive(true);
        }


        private void InstantiateDetailsUI(int target)
        {
            detailsUI = Instantiate(detailsUIPrefab, spawnDetailsTransform);
            detailsUI.transform.SetParent(spawnDetailsTransform);

            Transform detailItem = detailsUI.transform.GetChild(1).transform.GetChild(1);

            detailItem.GetChild(1).GetComponent<Image>().sprite = objectsInPickerSO_Array[target].sprite;
            detailItem.GetChild(2).GetComponent<TextMeshProUGUI>().text = objectsInPickerSO_Array[target].objectName;
            detailItem.GetChild(3).GetComponent<TextMeshProUGUI>().text = objectsInPickerSO_Array[target].Amount.ToString();

            if (detailsUI.GetComponentInChildren<Button>())
            {
                Button btn = detailsUI.GetComponentInChildren<Button>();
                btn.onClick.AddListener(OnClickDeatilsUIBack);
            }
        }

        private int GetRandomObjectIndex () {
            int index  = random.Next(0, objectsInPickerSO_Array.Length);
            return index;
        }

        public void OnClickDeatilsUIBack(){
            if(spawnDetailsTransform.GetChild(0).gameObject){
                spinnerUI_Script.ChangeCoinText();
                Destroy(spawnDetailsTransform.GetChild(0).gameObject);
                tranparentRewardBG.SetActive(false);
            }
        }
        
        private void SetCoins(int newCoins)
        {
            Preference.Instance.User.coins += newCoins;
            Preference.Instance.SaveData();
        }
        private int GetCoins()
        {
            return Preference.Instance.User.coins;
        }
        public void ActiveSpinButton(){
            spinButton.interactable = true;
            // spinText.text = "Spin";
        }
        public void ResetRotation(){
            spinningCircle.transform.rotation = Quaternion.identity;
        }
        public void ActiveCoinSpinButton(){
            if(!spinButton.gameObject.activeSelf){
                coinSpinButton.gameObject.SetActive(true);
            }
        }
    }
