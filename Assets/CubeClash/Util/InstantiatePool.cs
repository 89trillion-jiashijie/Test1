using System.Collections.Generic;
using UnityEngine;

namespace CubeClash.Scripts.Assembly.Util
{
    public class InstantiatePool<T> where T : MonoBehaviour, IInstantiatedItem
    {
        private readonly T prefab;
        private readonly List<T> loadedCells;

        public InstantiatePool(T prefab)
        {
            this.prefab = prefab;
            loadedCells = new List<T>();
        }

        public List<T> GetAllActivationItem()
        {
            return loadedCells.FindAll(x => x.Active);
        }

        public List<T> InstantiateAll(int maxCapacity, Transform container)
        {
            List<T> list = new List<T>();
            for (var i = 0; i < maxCapacity; i++)
            {
                T cell = Instantiate(i, container);
                cell.Active = true;
                list.Add(cell);
            }

            HideExcessCells(maxCapacity);
            return list;
        }

        public T Instantiate(int index, Transform container)
        {
            return GetCellByIndex(index, container);
        }

        public void HideExcessCells(int maxCapacity)
        {
            for (int i = maxCapacity; i < loadedCells.Count; i++)
            {
                T cell = loadedCells[i];
                cell.Active = false;
                cell.gameObject.SetActive(false);
            }
        }

        public void Destroy()
        {
            foreach (var loadedCell in loadedCells)
            {
                if (loadedCell)
                {
                    GameObject.Destroy(loadedCell.gameObject);
                }
            }

            loadedCells.Clear();
        }

        private T GetCellByIndex(int index, Transform container)
        {
            if (index >= loadedCells.Count)
            {
                for (int i = loadedCells.Count; i <= index; i++)
                {
                    loadedCells.Add(GameObject.Instantiate(prefab, container));
                }
            }

            loadedCells[index].gameObject.SetActive(true);
            return loadedCells[index];
        }
    }
}