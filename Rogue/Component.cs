using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
    abstract class Component
    {
        public GameObject gameObject;
        public virtual void Start() { }
    }
}
