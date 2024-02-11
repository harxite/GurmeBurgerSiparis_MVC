using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum OrderStatus
    {
        Received = 1,         // Sipariş alındı
        InProgress,       // Hazırlanıyor
        ReadyForPickup,   // Teslim için hazır
        OnTheWay,         // Yolda
        Delivered,        // Teslim edildi
        Canceled          // İptal edildi
    }
}
