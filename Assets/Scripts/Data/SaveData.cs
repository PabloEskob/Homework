using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    [Serializable]
    public class SaveData<T> where T : UniqueId
    {
        public List<T> SaveDataList = new();

        public T FindById(string id)
        {
            return SaveDataList.FirstOrDefault(data => data.Id == id);
        }

        public void AddToList(T saveData)
        {
            SaveDataList.RemoveAll(data => data.Id == saveData.Id);
            SaveDataList.Add(saveData);
        }
    }
}