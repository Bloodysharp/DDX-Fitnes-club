using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Model
{
    public class StatisticModel
    {
         public Guid ID { get; set; }
        public DateTime MonthYear { get; set; }
        public decimal TotalSubscriptionsRevenue { get; set; }
        public decimal TrainersSalaryExpense { get; set; }
        public decimal ManagersSalaryExpense { get; set; }
        public decimal RepairCosts { get; set; }
        public decimal EquipmentPurchaseCosts { get; set; }
    }
}
