﻿namespace CashRegisterStore.DAL.Data.Entities
{
    public class BasketProduct
    {
        public long BasketId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}