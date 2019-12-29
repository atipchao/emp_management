using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.ViewModes
{
    public class EmpEditViewModel : EmpCreateViweModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
