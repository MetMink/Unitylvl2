using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GameBase : MonoBehaviour
{
    protected Transform _myTransform;
    protected GameObject _instanceObject;
    protected string _name;
    protected bool _isVisible;


    protected Vector3 _position;
    protected Vector3 _scale;
    protected Quaternion _rotation;

    protected Material _material;
    protected Color _color;

    protected Rigidbody _rigidbody;
    protected int _layer;

    protected virtual void Awake()
    {
        _instanceObject = this.gameObject;
        _name = _instanceObject.name;
        if (GetComponent<Renderer>())
        {
            _material = GetComponent<Renderer>().material;
        }
        _rigidbody = _instanceObject.GetComponent<Rigidbody>();
        _myTransform = _instanceObject.transform;
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
            InstanceGameObject.name = _name;
        }
    }

    public Color Color
    {
        get
        {
            return _color;
        }
        set
        {
            _color = value;
            if(_material != null)
            {
                _material.color = _color;
            }
            
        }
    }
    public int Layer
    {
        get
        {
            return _layer;
        }
        set
        {
            if(_instanceObject != null)
            {
                _instanceObject.layer = _layer;
            }
            
        }
    }
    public Material GetMaterial
    {
        get { return _material; }
    }
    public GameObject InstanceGameObject
    {
        get { return _instanceObject; }
    }
    public Rigidbody GetRigidbody
    {
        get { return _rigidbody; }
    }

    public Vector3 Position
    {
        get
        {
            if(InstanceGameObject!= null)
            {
                _position = _myTransform.position;
            }
            return _position;
        }
        set
        {
            _position = value;
            if (InstanceGameObject != null)
            {
                _myTransform.position = _position;
            }
        }
    }

    public Vector3 Scale
    {
        get
        {
            if (InstanceGameObject != null)
            {
                _scale = _myTransform.localScale;
            }
            return _scale;
        }
        set
        {
            _scale = value;
            if (InstanceGameObject != null)
            {
                _myTransform.localScale = _scale;
            }
        }
    }

    public Quaternion rotation
    {
        get
        {
            if (InstanceGameObject != null)
            {
                _rotation = _myTransform.rotation;
            }
            return _rotation;
        }
        set
        {
            _rotation = value;
            if (InstanceGameObject != null)
            {
                _myTransform.rotation = _rotation;
            }
        }
    }

    public bool IsVisible
    {
        get { return _isVisible; }
        set
        {
            _isVisible = value;
            if(_instanceObject.GetComponent<MeshRenderer>())
            {
                _instanceObject.GetComponent<MeshRenderer>().enabled = _isVisible;
            }
        }
    }


    private void AskLayer(Transform obj, int lvl)
    {
        obj.gameObject.layer = lvl;
        if(obj.childCount > 0)
        {
            foreach(Transform t in obj)
            {
                AskLayer(t, lvl);
            }
        }
    }

    private void AskColor(Transform obj, Color col)
    {
        if (obj.GetComponent<Renderer>() != null)
        {
            obj.GetComponent<Renderer>().material.color = col;
        }
            if (obj.childCount > 0)
            {
                foreach (Transform t in obj)
                {
                    AskColor(t, col);
                }
            }
    }
}
