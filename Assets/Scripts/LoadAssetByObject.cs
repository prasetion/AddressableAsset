using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetByObject : MonoBehaviour{

    public UnityEngine.AddressableAssets.AssetReference Barrel;
    [SerializeField] private GameObject _MyGameObject;

    void Start(){
       LoadedAsset();
    }

    void Update(){
        if(Input.GetKeyUp(KeyCode.Space)){
            Instantiate(_MyGameObject);
        }
    }

    void LoadedAsset(){
        UnityEngine.AddressableAssets.LoadAsset<GameObject>().Completed += LoadDone;
    }

    void LoadDone(UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation<GameObject> obj){
        _MyGameObject = obj.Result;
        Debug.Log("finish load asset");
    }

}
