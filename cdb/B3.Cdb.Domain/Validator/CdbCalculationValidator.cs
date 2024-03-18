using B3.Cdb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Domain.Validator;
public class CdbCalculationValidator
{
    public void Validate(Operation operation)
    {
        if (operation.Principal <= 0)
            throw new ArgumentException("Initial value must be greater than zero");

        if (operation.Months <= 1)
            throw new ArgumentException("Months must be greater than one");
    }
}
