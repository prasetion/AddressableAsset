using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadAssetByAddress : MonoBehaviour
{
    [SerializeField] private string _AssetAddress;
    [SerializeField] private GameObject _MyGameObject;

    // Start is called before the first frame update
    void Start(){
        LoadedAsset(_AssetAddress);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update(){
        if(Input.GetKeyUp(KeyCode.Space)){
            Instantiate(_MyGameObject);
        }
    }

    void LoadedAsset(string addressName){
        UnityEngine.AddressableAssets.Addressables.LoadAsset<GameObject>(addressName).Completed += LoadDone;
    }

    void LoadDone(UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation<GameObject> obj){
        _MyGameObject = obj.Result;
        Debug.Log("finish load asset");
    }

}
