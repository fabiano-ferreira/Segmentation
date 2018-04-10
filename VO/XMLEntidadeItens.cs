using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VO
{
    [Serializable]
    [XmlRoot("Descricao")]
    public class XMLEntidadeItens
    {
        [XmlAttribute("Descricao")]
        public string Descricao { get; set; }
        [XmlArrayItem("Entidade")]
        public List<XMLEntidadeSubItens> Entidade { get; set; }
    }
}
