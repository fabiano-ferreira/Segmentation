using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VO
{
    [Serializable]
    public class XMLEntidadeSubItens
    {
        [XmlAttribute("Nome")]
        public string Nome { get; set; }
        [XmlAttribute("Documento")]
        public string Documento { get; set; }
        [XmlAttribute("Codigo")]
        public string Codigo { get; set; }
        [XmlAttribute("Valor")]
        public string Valor { get; set; }
        [XmlAttribute("IdentificadorDominio")]
        public string IdentificadorDominio { get; set; }
        [XmlArrayItem("Var")]
        public List<XMLEntidadeSubItens> Var { get; set; }
    }
}
