using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CashRegisterApi.Model
{
    public class ReceiptLine: INotifyPropertyChanged
    {
        [Key]
        private int IDValue;
        [JsonPropertyName("id")]
        public int ID
        {
            get => IDValue;
            set
            {
                IDValue = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        private int BoughtProductIDValue;
        [JsonPropertyName("boughtProductId")]
        public int BoughtProductID
        {
            get => BoughtProductIDValue;
            set
            {
                BoughtProductIDValue = value;
                OnPropertyChanged(nameof(BoughtProductID));
            }
        }
        private Product BoughtProductValue;
        [JsonPropertyName("boughtProduct")]
        public Product BoughtProduct
        {
            get => BoughtProductValue;
            set
            {
                BoughtProductValue = value;
                OnPropertyChanged(nameof(BoughtProduct));
            }
        }
        private int AmountValue;
        [JsonPropertyName("amount")]
        public int Amount
        {
            get => AmountValue;
            set
            {
                AmountValue = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        private decimal TotalPriceValue;
        [JsonPropertyName("totalPrice")]
        public decimal TotalPrice
        {
            get => TotalPriceValue;
            set
            {
                TotalPriceValue = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
