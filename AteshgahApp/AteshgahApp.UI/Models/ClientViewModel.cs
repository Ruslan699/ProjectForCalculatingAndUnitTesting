using System;
using System.ComponentModel.DataAnnotations;

namespace AteshgahApp.UI.Models
{
    public class ClientViewModel
    {
        public Guid ClientUniqueId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string TelephoneNr { get; set; }
    }
}