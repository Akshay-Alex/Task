using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Viewer : MonoBehaviour
{
    private Quaternion initialRotation;
    [SerializeField]
    private Transform parentTransform;
    public List<Transform> childObjects;
    public Material TransparentMaterial;
    public Dictionary<GameObject, Material> OriginalMaterials = new Dictionary<GameObject, Material>();
    public List<GameObject> ExternalObjects;
    public Transform CurrentCamera;
    public bool _isTransparent;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        _isTransparent = false;
        StoreInitialMaterial();
    }

    // Update is called once per frame
    void Update()
    {/*
        if(Input.GetMouseButton(0))
        {
            Vector3 forwardDirection = Input.mousePosition - parentTransform.position;
            Quaternion rotation = Quaternion.LookRotation(forwardDirection, Vector3.up);
            rotation.x = 0;
            rotation.y = 0;
            parentTransform.rotation = rotation;
        }
        if (Input.GetMouseButton(2))
        {
            Vector3 forwardDirection = Input.mousePosition - parentTransform.position;
            Quaternion rotation = Quaternion.LookRotation(forwardDirection, Vector3.up);
            rotation.z = 0;
            rotation.y = 0;
            parentTransform.rotation = rotation;
        }
        */

    }
    public void RotateLeft()
    {
        DisableAnimator();
        parentTransform.rotation = Quaternion.Euler(parentTransform.eulerAngles + new Vector3(0f, 45f, 0f));
    }
    public void RotateRight()
    {
        DisableAnimator();
        parentTransform.rotation = Quaternion.Euler(parentTransform.eulerAngles + new Vector3(0f, -45f, 0f));
    }
    public void RotateUp()
    {
        DisableAnimator();
        parentTransform.rotation = Quaternion.Euler(parentTransform.eulerAngles + new Vector3(45f, 0f, 0f));
    }
    public void RotateDown()
    {
        DisableAnimator();
        parentTransform.rotation = Quaternion.Euler(parentTransform.eulerAngles + new Vector3(-45f, 0f, 0f));
    }
    public void ZoomIn()
    {
        DisableAnimator();
        CurrentCamera.position = CurrentCamera.position + new Vector3(0f, 0f, 1f);
    }
    public void ZoomOut()
    {
        DisableAnimator();
        CurrentCamera.position = CurrentCamera.position + new Vector3(0f, 0f, -1f);
    }
    public void PanLeft()
    {
        DisableAnimator();
        parentTransform.position = parentTransform.position + new Vector3(-1f, 0f, 0f);
    }
    public void PanRight()
    {
        DisableAnimator();
        parentTransform.position = parentTransform.position + new Vector3(1f, 0f, 0f);
    }
    public void Explode()
    {
        DisableAnimator();
        foreach (Transform transform in childObjects)
        {
            transform.position = transform.position * 2;
        }
    }
    public void Implode()
    {
        DisableAnimator();
        foreach (Transform transform in childObjects)
        {
            transform.position = transform.position / 2;
        }
    }
    public void MakeTransparent()
    {
        foreach (GameObject gameObject in ExternalObjects)
        {
            gameObject.GetComponent<MeshRenderer>().material = TransparentMaterial;
        }
    }
    public void MakeOpaque()
    {
        foreach (GameObject gameObject in ExternalObjects)
        {
            gameObject.GetComponent<MeshRenderer>().material = OriginalMaterials[gameObject];
        }
    }
    public void ToggleTransparency()
    {
        DisableAnimator();
        if (_isTransparent)
        {
            MakeOpaque();
            _isTransparent = false;
        }
        else
        {
            MakeTransparent();
            _isTransparent = true;
        }
    }
    public void StoreInitialMaterial()
    {
        foreach (GameObject gameObject in ExternalObjects)
        {
            OriginalMaterials.Add(gameObject, gameObject.GetComponent<MeshRenderer>().material);
        }
    }
    public void PlayAnimation()
    {
        animator.enabled = true;
        animator.Play("Rotate");
    }
    public void DisableAnimator()
    {
        animator.enabled = false;
    }
}
