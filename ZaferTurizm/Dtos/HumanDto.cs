using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;
using ZaferTurizm.Domain.Enum;

namespace ZaferTurizm.Dtos
{
    public class HumanDto
    {
        public HumanDto()
        {
            //CinsiyetList = Enum.GetValues(typeof(CinsiyetEnum)).Cast<CinsiyetEnum>()
            //    .Select(v => new SelectListItem()
            //    {
            //        Text = v.ToString(),
            //        Value =Convert.ToString((int)v)
            //    }).ToList();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Kimlik { get; set; }
        public DateTime BirhtDay { get; set; }
        public CinsiyetEnum Cinsiyet { get; set; }
        public string Cinsiyets { get; set; }
        public IEnumerable<SelectListItem> CinsiyetList { get; set; }
        public string Mail { get; set; }
    }
}
