﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Enum
{
    public enum Operation
    {
        Increment   = 1, //Adiciona
        Decrement   = 2, //Subtrai
        Reserved    = 3,
        Payment     = 4,
        NoPayment   = 5,
        RemoveItemShopCart = 6

    }
}
