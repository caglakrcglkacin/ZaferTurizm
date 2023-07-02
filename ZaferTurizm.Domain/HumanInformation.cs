using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain.Enum;

namespace ZaferTurizm.Domain
{
    public class HumanInformation:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Kimlik { get; set; }
        public DateTime BirhtDay { get; set; }
        public CinsiyetEnum Cinsiyet { get; set; }
        public string Mail { get; set; }
    }
}
