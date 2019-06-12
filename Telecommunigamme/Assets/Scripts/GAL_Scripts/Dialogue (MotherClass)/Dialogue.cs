using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

/*[System.Serializable]
public class Dialogue 
{
    public string name;

    [TextArea(3,10)]
    public string[] sentences;
}*/

//[XmlRoot("Dialogue")]
public class Dialogue
{
    public List<Speech> discution;

    
    /*  [XmlAttribute]
      public string Name
      {
          get;
          set;
      }

      public string[] Sentences
      {
          get;
          set;
      }

      public Dialogue()
      {

      }*/


}