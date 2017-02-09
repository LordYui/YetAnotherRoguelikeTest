using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
    class GameObject
    {
        public static List<GameObject> GameObjects = new List<GameObject>();
        public string Name { get; private set; }

        public GameObject(string name = "")
        {
            if (name == "")
                name = $"gameobject_{GameObjects.Count}";
            Name = name;
            GameObjects.Add(this);
        }

        #region Components
        private List<Component> componentList = new List<Component>();
        public T AddComp<T>() where T : Component
        {
            T newComp = Activator.CreateInstance<T>();
            newComp.gameObject = this;
            newComp.Start();

            componentList.Add(newComp);

            return newComp;
        }

        public bool RemoveComp<T>() where T : Component
        {
            return componentList.RemoveAll(c => c is T) > 0;
        }

        public T GetComp<T>() where T : Component
        {
            return (T)componentList.Where(c => c is T).FirstOrDefault();
        }

        public bool HasComponent<T>() where T : Component
        {
            return GetComp<T>() != null;
        }
        #endregion

        #region Static methods
        public static GameObject[] GetByComponent<T>() where T : Component
        {
            return GameObjects.Where(go => go.HasComponent<T>()).ToArray();
        }
        #endregion
    }
}
