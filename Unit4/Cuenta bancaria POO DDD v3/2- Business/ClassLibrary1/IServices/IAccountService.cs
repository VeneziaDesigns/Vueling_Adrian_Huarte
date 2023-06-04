using Domain;
using System.Collections.Generic;

namespace Business
{
    public interface IAccountService
    {
        decimal? AniadirIngreso(decimal cash);
        decimal? AniadirGasto(decimal cash);
        List<Incomes> IncomesList();
        List<Outcomes> OutcomesList();
        string Balance();
    }
}