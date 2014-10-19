using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SB2Revival.ElemCl
{
    /// <summary>
    /// Used to know what type of elem it is(may not even be implemented)
    /// </summary>
    public class Element
    {
        #region Values
        int id;
        string name;
        #endregion
        #region class
        /// <summary>
        /// used to set a new element, will be used to create new elements in the editor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public Element(string name, int id)
        {
            this.name = name; this.id = id;
        }
        /// <summary>
        /// blank class, used for loading element files
        /// </summary>
        public Element()
        { }
        #endregion
        #region logic
        /// <summary>
        /// this loads the element from the file
        /// </summary>
        /// <param name="file"></param>
        public void loader(string file)
        {
            using (BinaryReader temp = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                this.id = temp.ReadInt32();
                this.name = temp.ReadString();
            }
        }
        /// <summary>
        /// this writes the file to harddrive
        /// </summary>
        public void Writer()
        {
            this.CHkLoc(Environment.CurrentDirectory + @"\Data\Game\Elements\");
            using (BinaryWriter temp = new BinaryWriter(File.Open(Environment.CurrentDirectory + @"\Data\Game\Elements\" + this.name+@".EM", FileMode.Create)))
            {
                
                temp.Write(id);
                temp.Write(name);
            }
        }
        private void CHkLoc(string file)
        {
            if (!Directory.Exists(file))
            {Directory.CreateDirectory(file);}
        }
        #endregion
        #region get/set
        public string Name
        {
            get
            {
                return this.name;
            }
            private set { this.name = value; }
        }
        public int Id
        {
            get
            {
                return this.id;
            }
            private set { this.id = value; }
        }
        #endregion
    }
}
