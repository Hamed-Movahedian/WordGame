using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgsCommonLib;
using UnityEngine;
using Object = UnityEngine.Object;

public class PoolManager : MgsSingleton<PoolManager>
{
    private readonly Dictionary<Component, List<Component>> _prefabToObj=new Dictionary<Component, List<Component>>();

    private readonly Dictionary<Component, Component> _objToPrefab=new Dictionary<Component, Component>();

    public void Return(Component obj)
    {
        if (_objToPrefab.ContainsKey(obj))
        {
            _prefabToObj[_objToPrefab[obj]].Add(obj);
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(transform);
        }
        else
        {
            Object.Destroy(obj.gameObject);
        }
    }

    public Component Create(Component prefab)
    {
        if (!_prefabToObj.ContainsKey(prefab))
        {
            _prefabToObj[prefab]=new List<Component>();
        }

        var list = _prefabToObj[prefab];

        Component result;

        if (list.Any())
        {
            result = list[0];
            list.Remove(result);
        }
        else
        {
            result = Instantiate(prefab);
            _objToPrefab[result] = prefab;
        }

        result.gameObject.SetActive(true);

        return result;
    }
}