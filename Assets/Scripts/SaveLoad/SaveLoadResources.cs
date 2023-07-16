using Data;
using Factory;
using Other;
using UnityEngine;

namespace SaveLoad
{
    public class SaveLoadResources : SaveLoader<ResourcesData,ResourcesFactory>
    {
        private readonly ResourcesFactory _resourcesFactory;
        public SaveLoadResources(ResourcesFactory service) : base(service)
        {
            _resourcesFactory = service;
        }
        
        protected override ResourcesData ConvertToData(ResourcesFactory service)
        {
            ResourcesData unitData = new ResourcesData();

            foreach (ResourceObject unit in _resourcesFactory.ListData)
            {
                SaveResourcesData resourcesData = new SaveResourcesData(unit.Id, unit.ResourceType)
                {
                    Id = unit.Id,
                    Position = unit.transform.position.AsVectorData(),
                    Rotation = unit.transform.rotation.AsQuaternionData()
                };
                unitData.AddToList(resourcesData);
            }

            return unitData;
        }

        protected override void SetupData(ResourcesFactory service, ResourcesData data)
        {
            foreach (ResourceObject unitObject in _resourcesFactory.ListData)
            {
                SaveResourcesData saveUnit = data.FindById(unitObject.Id);

                if (saveUnit != null)
                {
                    unitObject.transform.position = saveUnit.Position.AsUnityVector();
                    unitObject.transform.rotation = saveUnit.Rotation.AsUnityQuaternion();
                }
            }
        }

        protected override void SetupByDefault(ResourcesFactory service)
        {
           Debug.Log("no data");
        }
    }
}