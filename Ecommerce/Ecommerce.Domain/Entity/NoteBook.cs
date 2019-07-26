using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Entity
{
    public class NoteBook : Product
    {   /// <summary>
        /// Data Cadastro do Produto
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Marca do produto
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// Modelo do produto
        /// </summary>
        public string  Model { get; set; }
    }
}
