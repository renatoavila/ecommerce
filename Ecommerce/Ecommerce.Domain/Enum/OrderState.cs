using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Enum
{
    public enum OrderState
    {
        New         =1, //Novo
        Hold        =2, //Aguarde
        Shipper     =3, //Enviado
        Delivered   =4, //Entregue
        Closed      =5  //Encerrado

    }
}
