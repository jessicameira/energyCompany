using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace energyCompany.models
{
    interface IEndpoint
    {
        string SerialNumber { get; set; }
        int ModelId { get; set; }
        string ModelDescription { get; set; }
        int Number { get; set; }
        string FirmwareVersion { get; set; }
        int State { get; set; }
        string StateDescription { get; set; }

        void Create(string serialNumber, int ModelId, int Number, string FirmwareVersion, int state);
        void Update(string serialNumber, int state);
        void Delete(string serialNumber);
        void ListAll();
        void FindBy(string serialNumber);
    }
}
