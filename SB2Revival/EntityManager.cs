using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SB2Revival.CharaClasses;
namespace SB2Revival
{
    public class EntityManager
    {
        #region virtial
        readonly Dictionary<string, Entity> entityData = new Dictionary<string, Entity>();

        #endregion
        #region gets/sets
        public Dictionary<string, Entity> EntityData
        {
            get { return entityData; }
        }
        #endregion
    }
}
