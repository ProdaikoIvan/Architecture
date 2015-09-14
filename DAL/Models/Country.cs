using System.Collections.Generic;

namespace DAL.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<TemplateEntity> TemplateEntities { get; set; }
    }
}