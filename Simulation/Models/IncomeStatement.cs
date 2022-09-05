namespace Simulation.Models
{
    public class IncomeStatement
    {
        public decimal Sales { get; set; }
        public decimal AmortisationExpense { get; set; }
        public decimal IncomeTaxExpense { get; set; }
        public decimal ProfitAfterTax { get; set; }
    }
}
